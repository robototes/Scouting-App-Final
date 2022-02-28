using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountChange : MonoBehaviour
{
    public string text = "Button";
    public int countVal = 1;
    public int id = 0;
    private Button but;
    private Display[] myDisplays;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<TMP_Text>().text = text;
        Display[] temp = FindObjectsOfType<Display>();
        int size = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            if(temp[i].id == this.id)
            {
                size++;
            }
        }

        myDisplays = new Display[size];

        int displayItterator = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            if(temp[i].id == this.id)
            {
                myDisplays[displayItterator] = temp[i];
                displayItterator++;
            }
        }
        but = GetComponent<Button>();
        but.onClick.AddListener(increase);
    }
    public void increase()
    {
        for(int i = 0; i < myDisplays.Length; i++)
        {
            myDisplays[i].count += countVal;
            GameManager.updateDisplay.Invoke();
        }
    }
    
}
