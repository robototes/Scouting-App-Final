using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ExportButton : MonoBehaviour 
{    
    public string wuj;
    public string filePath;
    public bool makeCsv;
    public bool writeTeamAndMatch;
    public StreamWriter writer;
    private string output = "";
    private string[] objects;
    private Display[] displays;
    private ImageDetector2[] map;
    private BooleanBox[] booleanBoxes;
    private TMP_InputField[] input;
    private Button but;

    // Use this for initialization
    void Start ()  
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(finalize);
        input = FindObjectsOfType<TMP_InputField>();
    }

    private void finalize() 
    {
        GameManager.CompileMap.Invoke();

        displays = FindObjectsOfType<Display>();
        map = FindObjectsOfType<ImageDetector2>();
        booleanBoxes = FindObjectsOfType<BooleanBox>();

        int matchTeamOffset;

        switch(writeTeamAndMatch)
        {
            case true:
            objects = new string[2 + displays.Length + (map.Length * 4) + booleanBoxes.Length];
            matchTeamOffset = 1;
            objects[0] = GameManager.matchNumber + "";
            objects[1] = GameManager.teamNumber + "";
            break;

            case false:
            objects = new string[displays.Length + (map.Length * 4) + booleanBoxes.Length + input.Length];
            matchTeamOffset = 0;
            break;
        }
        int ito = input.Length - 1;
        for(int i = 0; i < objects.Length; i++)
        {
            if (i < displays.Length)
            {
                objects[displays[i].id + matchTeamOffset] = displays[i].count + "";
            }
            if (i < map.Length)
            {
                objects[map[i].id + matchTeamOffset] = map[i].highGoal + "";
                objects[map[i].id + matchTeamOffset + map.Length] = map[i].lowGoal + "";

                objects[map[i].id + matchTeamOffset + map.Length * 2] = map[i].missHighGoal + "";
                objects[map[i].id + matchTeamOffset + map.Length * 3] = map[i].missLowGoal + "";

            }
            if (i < booleanBoxes.Length)
            {
                objects[booleanBoxes[i].id + 2] = booleanBoxes[i].value + "";
            }
            if (i < input.Length)
            {
                if(input[i].gameObject.name == "Name")
                {
                    objects[0] = input[i].text;
                }
                if(input[i].gameObject.name == "Match Number")
                {
                    objects[1] = input[i].text;
                    if(string.IsNullOrEmpty(input[i].text))
                    {
                        objects[1] = GameManager.matchNumber + 1 +"";
                    }
                }
                if(input[i].gameObject.name == "Team Number")
                {
                    objects[2] = input[i].text;
                    if(string.IsNullOrEmpty(input[i].text))
                    {
                        objects[2] = GameManager.teamNumber + "";
                    }
                }
            }
        }

        for(int i = 0; i < objects.Length; i++)
        {
            if (i == objects.Length - 1)
            {
                output += objects[i];
            }
            else
            {
                output += objects[i] + ",";
            }
        }        

        if (makeCsv)
        {
            GameManager._output += output;
            if(!System.IO.File.Exists(Application.persistentDataPath + "/OutputMaster.csv"))
            {
                writer = new StreamWriter(Application.persistentDataPath + "/OutputMaster.csv", true);
                writer.WriteLine("Name,Match,Team,-,GMMatch,GMTeam,autoLine,atotal,ah1,ah2,ah3,ah4,ah5,ah6,ah7,ah8,ah9,ah10,ah11,ah12,ah13,ah14,ah15,amh1,amh2,amh3,amh4,amh5,amh6,amh7,amh8,amh9,amh10,amh11,amh12,amh13,amh14,amh15,al1,al2,al3,al4,al5,al6,al7,al8,al9,al10,al11,al12,al13,al14,al15,aml1,aml2,aml3,aml4,aml5,aml6,aml7,aml8,aml9,aml10,aml11,aml12,aml13,aml14,aml15,-,def,climb,tTotal,th1,th2,th3,th4,th5,th6,th7,th8,th9,th10,th11,th12,th13,th14,th15,tmh1,tmh2,tmh3,tmh4,tmh5,tmh6,tmh7,tmh8,tmh9,tmh10,tmh11,tmh12,tmh13,tmh14,tmh15,tl1,tl2,tl3,tl4,tl5,tl6,tl7,tl8,tl9,tl10,tl11,tl12,tl13,tl14,tl15,tml1,tml2,tml3,tml4,tml5,tml6,tml7,tml8,tml9,tml10,tml11,tml12,tml13,tml14,tml15");
            }
            else
            {
                writer = new StreamWriter(Application.persistentDataPath + "/OutputMaster.csv", true);
            }
            writer.WriteLine(GameManager._output);
            writer.Close();
            print(GameManager._output);
            GameManager._output = "";
            GameManager.matchNumber++;
            if (GameManager.matchNumber < GameManager.teams.Length - 1)
            {
                GameManager.teamNumber = GameManager.teams[GameManager.matchNumber + 1];
            }
            else if (GameManager.matchNumber == GameManager.teams.Length && GameManager.matchNumber == GameManager.teams.Length + 1)
            {
                GameManager.teamNumber = GameManager.teams[GameManager.matchNumber + 1];
            }
        }
        else
        {
            GameManager._output += output + ",-,";
        }
        SceneManager.LoadScene(wuj);
    }
}