using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    public int id = 0;
    public string title;
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
        if (count < 0)
        {
            count = 0;
        }
        text.text = title + count;
    }

}
