using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public Sprite missSprite;
    public int id;
    public int goal;
    public bool hit;
    public Vector3 targetPos;
    private SpriteRenderer mySR;
    private ImageDetector2 myDetector;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(targetPos.x, targetPos.y, 0);
        mySR = GetComponent<SpriteRenderer>();
        if(!hit)
        {
            mySR.sprite = missSprite;
            if(goal == 1)
            {
                mySR.color = new Color(0.74f, 0, 0);
            }
            else
            {
                mySR.color = Color.red;
            }
        }
        else
        {
            if(goal == 1)
            {
                mySR.color = new Color(0, 0.69f, 0);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
