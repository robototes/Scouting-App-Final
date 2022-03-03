using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slider : MonoBehaviour
{
    public int id = 0;
    public int max;
    public int min;
    public int value;
    public GameObject knob;
    public TMP_Text minT;
    public TMP_Text maxT;
    private BoxCollider2D myCol;
    private Display[] myDisplays;
    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
        minT.text = "" + min;
        maxT.text = "" + max;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {   
            Touch finger = Input.GetTouch(0);
            Vector3 knobPosition = Camera.main.ScreenToWorldPoint(finger.position);
            if (finger.phase == TouchPhase.Moved || finger.phase == TouchPhase.Began)
            {
                if (myCol == Physics2D.OverlapPoint(knobPosition))
                {
                    knob.transform.position = new Vector3(knobPosition.x, knob.transform.position.y, 0);
                    
                    value = Mathf.RoundToInt((min - (0.5f + knob.transform.localPosition.x)) + (0.5f + knob.transform.localPosition.x) * (max + 1));
                    
                    for(int i = 0; i < myDisplays.Length; i++)
                    {
                        myDisplays[i].count = value;
                        GameManager.updateDisplay.Invoke();
                    }
                }
            }
        }
    }
}
