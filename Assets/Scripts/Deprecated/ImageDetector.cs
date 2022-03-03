using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDetector : MonoBehaviour
{
    public int id = 0;
    public int highGoal = 0;
    public int lowGoal = 0;
    public float clickdelay = 0.2f;
    private float clicktime = 0;
    private float clicked = 0;
    public Vector3 targetSize;
    public BoxCollider2D myCol;
    private FieldMap mappy;
    private bool hit;
    public Vector3 clickPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        targetSize.x *= GetComponentInParent<Transform>().localScale.x;
        targetSize.y *= GetComponentInParent<Transform>().localScale.y;

        transform.localScale = targetSize;

        myCol = GetComponent<BoxCollider2D>();

        mappy = FindObjectOfType<FieldMap>();

        GameManager.resetPosition.AddListener(clearPos);
    }
    void clearPos()
    {
        clickPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || hit)
        {   
            GameManager.resetPosition.Invoke();
            Touch finger = Input.GetTouch(0);
            Vector3 boxPosition = Camera.main.ScreenToWorldPoint(finger.position);

            if(finger.phase == TouchPhase.Began)
            {
                if (myCol == Physics2D.OverlapPoint(boxPosition))
                {
                    clicked++;
                    if (clicked == 1) 
                    {
                        clicktime = Time.time;
                    }
                    if (clicked > 1 && Time.time - clicktime < clickdelay)
                    {
                        clicked = 0;
                        clicktime = 0;
                    }
                    else if (clicked > 2 || Time.time - clicktime > 1) 
                    {
                        print("miss");
                        
                        clickPos = new Vector3(boxPosition.x, boxPosition.y, 0);
                        lowGoal++;
                        GameManager.updateMap.Invoke();
                        mappy.lastId = id;

                        clicked = 0;
                    }
                }
            }
        }
        if (highGoal < 0)
        {
            highGoal = 0;
        }
    }
}
