﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccelerateButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GlobalTimer.Instance.AccelerateGame();
            if (GetComponentInChildren<TextMeshProUGUI>() != null) {
                GetComponentInChildren<TextMeshProUGUI>().text ="x" + GlobalTimer.Instance.GetTimeMultiplier();
            }
            
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
