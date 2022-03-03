using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMap2 : MonoBehaviour
{
    public int rows = 0;
    public int collumns = 0;
    public int startingID = 0;
    public int netCount;
    public GameObject detectionSquare;
    public GameObject clickIndecator;
    public int lastId;
    public float clickdelay = 0.2f;
    public int value;
    public float clicked = 0;
    public float clicktime = 0;
    private SpriteRenderer mySR;
    private SpriteRenderer theirSR;
    private ImageDetector2[] squares;
    private Display[] myDisplays;
    //private List<GameObject> markers = new List<GameObject>();
    public BoxCollider2D myCol;
    private Vector3 boxPosition;
    private Switch swew;
    public Stack<GameObject> markers = new Stack<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        swew = FindObjectOfType<Switch>();
        myCol = GetComponent<BoxCollider2D>();
        Display[] temp = FindObjectsOfType<Display>();
        int size = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            if(temp[i].id == this.startingID)
            {
                size++;
            }
        }

        myDisplays = new Display[size];

        int displayItterator = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            if(temp[i].id == this.startingID)
            {
                myDisplays[displayItterator] = temp[i];
                displayItterator++;
            }
        }

        mySR = GetComponent<SpriteRenderer>();
        theirSR = detectionSquare.GetComponent<SpriteRenderer>();
        
        GameObject temperary;

        //sets the target size of detection squres
        Vector3 squareSize = new Vector3((mySR.bounds.size.x / theirSR.bounds.size.x) / collumns, (mySR.bounds.size.y / theirSR.bounds.size.y) / rows, 0);

        Vector3 startPos = new Vector3((transform.position.x - (mySR.bounds.size.x/2)) + squareSize.x/2, (transform.position.y + (mySR.bounds.size.y/2)) - squareSize.y/2, 0);

        int activeId = startingID+1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < collumns; j++)
            {
                temperary = Instantiate(detectionSquare, startPos, this.transform.rotation);

                temperary.GetComponent<ImageDetector2>().targetSize = squareSize;
                temperary.GetComponent<ImageDetector2>().id = activeId;

                temperary.transform.SetParent(this.transform);
                
                activeId++;
                startPos.x += squareSize.x;
            }
            startPos.x -= squareSize.x * collumns;
            startPos.y -= squareSize.y;
        }

        squares = FindObjectsOfType<ImageDetector2>();
    }
    private void Update() 
    {
        if(Time.time - clicktime > clickdelay && clicked == 1)
        {
            //hit
            placeMarker(boxPosition, true, swew.goal);
            value++;
            clicked = 0;
            clicktime = 0;
            updateText();
        }
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            boxPosition = Camera.main.ScreenToWorldPoint(finger.position);

            if(finger.phase == TouchPhase.Began)
            {
                if (myCol == Physics2D.OverlapPoint(boxPosition))
                {
                    clicked++;
                    if (clicked == 1) 
                    {
                        clicktime = Time.time;
                    }
                    if (clicked >= 2 && Time.time - clicktime < clickdelay)
                    {
                        //miss
                        placeMarker(boxPosition, false, swew.goal);
                        value++;
                        clicked = 0;
                        clicktime = 0;
                        updateText();
                    }
                }
            }
        }
        if (value < 0)
        {
            value = 0;
        }
        
    }
    void placeMarker(Vector3 position, bool hit, int goal)
    {
        GameObject temp = Instantiate(clickIndecator, position, transform.rotation);
        temp.transform.SetParent(this.transform);
        Marker tempMark = temp.GetComponent<Marker>();
        tempMark.hit = hit;
        tempMark.targetPos = position;
        tempMark.goal = goal;
        markers.Push(temp);
    }
    public void updateText()
    {
        for(int i = 0; i < myDisplays.Length; i++)
        {
            myDisplays[i].count = value;
            GameManager.updateDisplay.Invoke();
        }
    }
}
