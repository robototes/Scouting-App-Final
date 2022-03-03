using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public int goal = 0;
    public GameObject up;
    public GameObject down;
    private BoxCollider2D upCol;
    private BoxCollider2D downCol;
    private SpriteRenderer upSR;
    private SpriteRenderer downSR;
    // Start is called before the first frame update
    void Start()
    {
        upCol = up.GetComponent<BoxCollider2D>();
        downCol = down.GetComponent<BoxCollider2D>();

        upSR = up.GetComponent<SpriteRenderer>();
        downSR = down.GetComponent<SpriteRenderer>();

        upSR.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            Vector3 boxPosition = Camera.main.ScreenToWorldPoint(finger.position);
            
            if(finger.phase == TouchPhase.Began)
            {
                if (upCol == Physics2D.OverlapPoint(boxPosition))
                {
                    upSR.color = Color.green;
                    downSR.color = Color.grey;
                    goal = 0;
                }
                else if (downCol == Physics2D.OverlapPoint(boxPosition))
                {
                    downSR.color = Color.green;
                    upSR.color = Color.grey;
                    goal = 1;
                }
            }
        }
    }
}
