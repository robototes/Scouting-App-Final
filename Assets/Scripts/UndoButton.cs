using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UndoButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button but;
    private FieldMap2 map;

    // Use this for initialization
    void Start ()  
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(removePoint);
        map = FindObjectOfType<FieldMap2>();
    }

    void removePoint()
    {
        if (map.markers.Count > 0)
        {
            Destroy(map.markers.Pop());
        }
        map.value--;
        map.updateText();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
