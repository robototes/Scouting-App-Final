using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update    private Button but;
    public string wuj = "Beginning";
    private Button but;
    void Start ()  
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(UnBreak);
    }

    // Update is called once per frame
    void UnBreak()
    {
        FindObjectOfType<ExportButton>().output = "";
        SceneManager.LoadScene(wuj);
    }
}
