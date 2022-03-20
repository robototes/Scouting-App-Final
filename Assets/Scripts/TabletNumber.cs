using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabletNumber : MonoBehaviour
{
    public TMP_InputField wap;   
    // Start is called before the first frame update
    void Start()
    {
        //wap = GetComponent<TMP_InputField>();
        wap.text = "" + GameManager.tabletNumber; 
        //wap.onValueChanged.AddListener( delegate {updateGM();} );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateGM()
    {
        int.TryParse(wap.text, out GameManager.tabletNumber);
        GameManager.updateTabletNumber.Invoke();
        FindObjectOfType<ChangeMatchNum>().action();
    }
    
}
