using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeamMatchNumDisp : MonoBehaviour
{
    public TMP_Text Match;
    public TMP_Text Team;
    // Start is called before the first frame update
    void Start()
    {
        Match.text = "Match: " + GameManager.matchNumber;
        Team.text = "" + GameManager.teamNumber;
    }
}
