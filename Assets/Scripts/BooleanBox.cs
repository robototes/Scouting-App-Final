using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanBox : MonoBehaviour
{
    public int id = 0;
    public int value = 0;
    private BoxCollider2D myCol;
    private Display[] myDisplays;
    private SpriteRenderer mySR;
    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
        mySR = GetComponent<SpriteRenderer>();

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
            Vector3 boxPosition = Camera.main.ScreenToWorldPoint(finger.position);
            if (finger.phase == TouchPhase.Began)
            {
                if (myCol == Physics2D.OverlapPoint(boxPosition))
                {
                    if(value == 1)
                    {
                        mySR.color = Color.gray;
                        value = 0;
                    }
                    else
                    {
                        mySR.color = Color.green;
                        value = 1;
                    }

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
