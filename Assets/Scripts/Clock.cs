using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    private TMP_Text textClock;
    void Awake ()
    {
        textClock = GetComponent<TMP_Text>();
    }
    void Update ()
    {
        System.DateTime time = System.DateTime.Now;
        string hour = LeadingZero( time.Hour );
        string minute = LeadingZero( time.Minute );
        string second = LeadingZero( time.Second );
    textClock.text = hour + ":" + minute + ":" + second;
    }
    string LeadingZero (int n){
        return n.ToString().PadLeft(2, '0');
    }
}
