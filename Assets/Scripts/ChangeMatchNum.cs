using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeMatchNum : MonoBehaviour
{
    public TMP_InputField wap;  
    public TMP_InputField paw;   
    // Start is called before the first frame update
    void Start()
    {
        wap = GetComponent<TMP_InputField>(); 
        GameManager.updateDisplay.AddListener(UpdateText);
        wap.onValueChanged.AddListener(delegate { action(); });
        GameManager.updateDisplay.Invoke();
    }
    public void action()
    {
        int temp;
        int.TryParse(wap.text, out temp);
        if (!string.IsNullOrEmpty(wap.text) && temp <= GameManager.teams.Length && temp > 0)
        {
            GameManager.matchNumber = temp;
            GameManager.teamNumber = GameManager.teams[GameManager.matchNumber - 1];
        }
        else if (!string.IsNullOrEmpty(wap.text) && temp > GameManager.teams.Length && temp > 0)
        {
            GameManager.matchNumber = temp;
            GameManager.teamNumber = 0;
        }
        else if (temp <= 0)
        {
            GameManager.matchNumber = temp;
            GameManager.teamNumber = 0;
        }
        paw.text = GameManager.teamNumber + "";
    }
    private void UpdateText() 
    {
        wap.text = GameManager.matchNumber + "";
        paw.text = GameManager.teamNumber + "";
    }
    
}
