using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalTimerBinding : MonoBehaviour
{

    TextMeshProUGUI textBox;



    private void Start()
    {
        textBox = GetComponentInChildren<TextMeshProUGUI>();
    }


    private void Awake()
    {

    }


    private void Update()
    {
        
        int timerLeft =(int) GlobalTimer.Instance.GetTimeLeft();

        Debug.Log(timerLeft);

        textBox.text =""+ timerLeft/60 + ":" + timerLeft%60;
    }
}
