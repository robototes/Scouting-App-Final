using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    public int id = 0;
    public int count = 0;
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        updateText();
        GameManager.updateDisplay.AddListener(updateText);
    }

    void updateText()
    {
        text.text = "" + count;
    }

}
