using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static UnityEvent updateDisplay = new UnityEvent();
    public static UnityEvent updateMap = new UnityEvent();

}
