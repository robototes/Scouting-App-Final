using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameObject Instance;
    public static string _output = "";
    //public static string _header = "";
    public static int[] teams;
    public static int teamNumber = 9999;
    public static int matchNumber = 1;
    public static int tabletNumber = 99;
    public static int tabletReadRow = 1;
    public static string name = "";
    public string readerPath = "";
    private StreamReader reader;
    private StreamReader tabletConfigReader;
    public static UnityEvent updateDisplay = new UnityEvent();
    public static UnityEvent updateMap = new UnityEvent();
    public static UnityEvent resetPosition = new UnityEvent();
    public static UnityEvent CompileMap = new UnityEvent();
    public static UnityEvent CompileData = new UnityEvent();
    public static UnityEvent updateTabletNumber = new UnityEvent();
    private string input = "";

    private void Start() 
    {
        updateInput();
        teamNumber = teams[matchNumber - 1];
        updateDisplay.Invoke();
        updateTabletNumber.AddListener(updateInput);
    }
    private void updateInput()
    {
        tabletConfigReader = new StreamReader(Application.persistentDataPath + "/TabletConfig.txt");
        //sets tablet number to first row of TabletConfig.txt file
        int.TryParse(tabletConfigReader.ReadLine(), out tabletNumber);
        //sets tablet readfrom row to second row of TabletConfig.txt file
        int.TryParse(tabletConfigReader.ReadLine(), out tabletReadRow);
        
        tabletConfigReader.Close();

        if (readerPath == "")
        {
            readerPath = Application.persistentDataPath + "/MatchesInput.csv";
        }
        reader = new StreamReader(readerPath);
        for (int i = 1; i <= tabletReadRow; i++)
        {
            input = reader.ReadLine();
        }
        string[] temporal = input.Split(',');
        teams = new int[temporal.Length];
        for(int i = 0; i < temporal.Length; i++)
        {
            int.TryParse(temporal[i], out teams[i]);
            //do stuff
        }
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
