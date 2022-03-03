using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeldButton : MonoBehaviour
{
    public bool held = false;
    private BoxCollider2D myCol;
    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
    }
    public float clicked = 0;
    public float clicktime = 0.0f;
    public float clickdelay = 1.0f;
    // Update is called once per frame
    void Update()
    {    
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            Vector3 boxPosition = Camera.main.ScreenToWorldPoint(finger.position);
            if(finger.phase == TouchPhase.Stationary)
            {
                if (myCol == Physics2D.OverlapPoint(boxPosition))
                {
                    held = true;
                }
            }
            else if (finger.phase == TouchPhase.Ended || finger.phase == TouchPhase.Canceled)
            {
                held = false;
            }
            
        }
        
    }
}
