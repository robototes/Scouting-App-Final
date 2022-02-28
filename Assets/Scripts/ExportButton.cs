using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class ExportButton : MonoBehaviour 
{    
    public string filePath;
    private string output = "";
    private int[] objects;
    private Display[] displays;
    private ImageDetector[] map;
    private BooleanBox[] booleanBoxes;
    private Button but;

    // Use this for initialization
    void Start ()  
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(finalize);
        
        //StreamWriter outStream = System.IO.File.CreateText(Application.persistentDataPath+"match.csv");
    }

    private void finalize() 
    {
        displays = FindObjectsOfType<Display>();
        map = FindObjectsOfType<ImageDetector>();
        booleanBoxes = FindObjectsOfType<BooleanBox>();

        objects = new int[displays.Length + map.Length + booleanBoxes.Length];
        for(int i = 0; i < objects.Length; i++)
        {
            if (i < displays.Length)
            {
                objects[displays[i].id] = displays[i].count;
            }
            if (i < map.Length)
            {
                objects[map[i].id - 1] = map[i].value;
            }
            if (i < booleanBoxes.Length)
            {
                objects[booleanBoxes[i].id] = booleanBoxes[i].value;
            }
        }

        for(int i = 0; i < objects.Length; i ++)
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
        print(output);
        print(Application.persistentDataPath + " match.csv");
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + " match.csv");
        writer.WriteLine(output);
        output = ""; 
        writer.Close();
    }
}