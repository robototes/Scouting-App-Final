using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDetector2 : MonoBehaviour
{
    public int id = 0;
    
    public int highGoal = 0;
    public int lowGoal = 0;
    public int missHighGoal = 0;
    public int missLowGoal = 0;
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

        //GameManager.resetPosition.AddListener(clearPos);
        GameManager.CompileMap.AddListener(getVal);
    }
    void clearPos()
    {
        clickPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (highGoal < 0)
        {
            highGoal = 0;
        }
        if (lowGoal < 0)
        {
            lowGoal = 0;
        }
        if (missHighGoal < 0)
        {
            missHighGoal = 0;
        }
        if (missLowGoal < 0)
        {
            missLowGoal = 0;
        }
    }
    void getVal()
    {
        myCol.enabled = true;
        Marker[] mark = FindObjectsOfType<Marker>();
        for (int i = 0; i < mark.Length; i++)
        {
            if (myCol == Physics2D.OverlapPoint(mark[i].transform.position))
            {
                switch(mark[i].hit)
                {
                    case true:
                        if (mark[i].goal == 0)
                        {
                            highGoal++;
                        }
                        else if (mark[i].goal == 1)
                        {
                            lowGoal++;
                        }
                        break;
                    case false:
                        if (mark[i].goal == 0)
                        {
                            missHighGoal++;
                        }
                        else if (mark[i].goal == 1)
                        {
                            missLowGoal++;
                        }
                        break;
                }
            }
        }
    }
}
