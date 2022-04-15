using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
//using UnityEngine.Random;
public class Splash : MonoBehaviour
{
    TMP_Text text;
    public string[] texts;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        StreamReader sr = new StreamReader(Application.persistentDataPath + "/Splashes.txt");
        string temp = "";
        while(!sr.EndOfStream)
        {
            temp += sr.ReadLine() + ';';
        }
        texts = temp.Split(';');
        //print(texts[texts.Length - 3]);
        sr.Close();

        text.text = texts[Random.Range(0, texts.Length - 3)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
