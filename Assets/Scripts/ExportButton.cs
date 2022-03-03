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
    private string output = "";
    private int[] objects;
    private Display[] displays;
    private ImageDetector2[] map;
    private BooleanBox[] booleanBoxes;
    private TMP_InputField input;
    private Button but;

    // Use this for initialization
    void Start ()  
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(finalize);
        input = FindObjectOfType<TMP_InputField>();
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
            objects = new int[2 + displays.Length + (map.Length * 4) + booleanBoxes.Length];
            matchTeamOffset = 1;
            objects[0] = GameManager.matchNumber;
            objects[1] = GameManager.teamNumber;
            break;

            case false:
            objects = new int[displays.Length + (map.Length * 4) + booleanBoxes.Length];
            matchTeamOffset = 0;
            break;
        }

        for(int i = 0; i < objects.Length; i++)
        {
            if (i < displays.Length)
            {
                objects[displays[i].id + matchTeamOffset] = displays[i].count;
            }
            if (i < map.Length)
            {
                objects[map[i].id + matchTeamOffset] = map[i].highGoal;
                objects[map[i].id + matchTeamOffset + map.Length] = map[i].lowGoal;

                objects[map[i].id + matchTeamOffset + map.Length * 2] = map[i].missHighGoal;
                objects[map[i].id + matchTeamOffset + map.Length * 3] = map[i].missLowGoal;

            }
            if (i < booleanBoxes.Length)
            {
                objects[booleanBoxes[i].id + 2] = booleanBoxes[i].value;
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
            print(GameManager._output);
            //StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/match" + objects[0] + "team" + objects[1] + ".csv");
            //writer.WriteLine(output);
            //writer.Close();
            Destroy(FindObjectOfType<GameManager>().gameObject);
        }
        else
        {
            GameManager._output += output + ",-,";
        }
        SceneManager.LoadScene(wuj);
    }
}