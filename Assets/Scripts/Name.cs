using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Name : MonoBehaviour
{
    public TMP_InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<TMP_InputField>();
        input.text = GameManager.name;
        input.onValueChanged.AddListener(delegate {changeGMVal();});
    }
    void changeGMVal()
    {
        GameManager.name = input.text;
    }  
}
