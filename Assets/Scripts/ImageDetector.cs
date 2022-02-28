using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDetector : MonoBehaviour
{
    public int id = 0;
    public int value = 0;
    public Vector3 targetSize;
    public BoxCollider2D myCol;
    private FieldMap mappy;
    // Start is called before the first frame update
    void Start()
    {
        targetSize.x *= GetComponentInParent<Transform>().localScale.x;
        targetSize.y *= GetComponentInParent<Transform>().localScale.y;

        transform.localScale = targetSize;

        myCol = GetComponent<BoxCollider2D>();

        mappy = FindObjectOfType<FieldMap>();
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
                    mappy.netCount++;
                    value++;
                    GameManager.updateMap.Invoke();
                    mappy.lastId = id;
                }
            }
        }
        if (value < 0)
        {
            value = 0;
        }
    }
}
