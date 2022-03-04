using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameObject Instance;
    public static string _output = "";
    public static int[] teams;
    public static int teamNumber = 9999;
    public static int matchNumber = 1;
    public string readerPath = "";
    private StreamReader reader;
    public static UnityEvent updateDisplay = new UnityEvent();
    public static UnityEvent updateMap = new UnityEvent();
    public static UnityEvent resetPosition = new UnityEvent();
    public static UnityEvent CompileMap = new UnityEvent();
    public static UnityEvent CompileData = new UnityEvent();

    private void Start() 
    {
        if (readerPath == "")
        {
            readerPath = Application.persistentDataPath + "/MatchesInput.csv";
        }
        reader = new StreamReader(readerPath);
        string input = reader.ReadLine();
        string[] temporal = input.Split(',');
        teams = new int[temporal.Length];
        for(int i = 0; i < temporal.Length; i++)
        {
            int.TryParse(temporal[i], out teams[i]);
            //do stuff
        }
        teamNumber = teams[matchNumber - 1];
        updateDisplay.Invoke();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this.gameObject;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
    }
}
