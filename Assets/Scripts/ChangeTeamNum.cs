using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class ChangeTeamNum : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField wap;   
    // Start is called before the first frame update
    void Start()
    {
        wap = GetComponent<TMP_InputField>(); 
        //wap.GetComponentInChildren<TMP_Text>().text = System.IO.Directory.GetCurrentDirectory("/storage/Documnets")[1];
        //print(System.IO.Directory.GetDirectories("Storage/Documnets"));
    }

    // Update is called once per frame
    //public string[] wub = new string[2];
    void Update()
    {
        int.TryParse(wap.text, out GameManager.teamNumber);
    }
}
