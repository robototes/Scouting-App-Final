using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
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
            mySR.color = Color.red;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
