using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMap : MonoBehaviour
{
    public int rows = 0;
    public int collumns = 0;
    public int startingID = 0;
    public int netCount;
    public GameObject detectionSquare;
    public int lastId;
    private SpriteRenderer mySR;
    private SpriteRenderer theirSR;
    private ImageDetector[] squares;
    private Display[] myDisplays;
    // Start is called before the first frame update
    void Start()
    {
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

                temperary.GetComponent<ImageDetector>().targetSize = squareSize;
                temperary.GetComponent<ImageDetector>().id = activeId;

                temperary.transform.SetParent(this.transform);
                
                activeId++;
                startPos.x += squareSize.x;
            }
            startPos.x -= squareSize.x * collumns;
            startPos.y -= squareSize.y;
        }

        squares = FindObjectsOfType<ImageDetector>();

        GameManager.updateMap.AddListener(increase);
    }
    private void Update() 
    {
        
    }
    void increase()
    {
        for (int i = 0; i < myDisplays.Length; i++)
        {
            myDisplays[i].count++;
            if (myDisplays[i].count < netCount)
            {
                for (int j = 0; j < squares.Length; j++)
                {
                    if (squares[j].id == lastId)
                    {
                        squares[j].value -= netCount - myDisplays[i].count;
                    }
                }
                netCount = myDisplays[i].count;
            }
        }
        GameManager.updateDisplay.Invoke();
    }
}
