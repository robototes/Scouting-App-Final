using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static string _output = "";
    public static int teamNumber = 9999;
    public static int matchNumber = 9999;
    public string readerPath;
    private StreamReader reader;
    public static UnityEvent updateDisplay = new UnityEvent();
    public static UnityEvent updateMap = new UnityEvent();
    public static UnityEvent resetPosition = new UnityEvent();
    public static UnityEvent CompileMap = new UnityEvent();
    public static UnityEvent CompileData = new UnityEvent();

    private void Start() 
    {
        DontDestroyOnLoad(this.gameObject);
        for(int i = 0; i < reader.ReadLine().Length; i++)
        {
            //do stuff
        }
    }

/*
    public string output
    {
        get
        {
            return _output;
        }
        set
        {
            _output = value;
        }
    }
*/
}
