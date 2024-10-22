﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ChangeAmount : MonoBehaviour
{
    [SerializeField]
    Button buyButton;
    [SerializeField]
    int amount;
    GameObject planet;

    private void Start()
    {
        buyButton.onClick.AddListener(OnClickToBuy);
    }
    void OnClickToBuy()
    {
        List<GameObject> Continents = planet.GetComponentsInChildren<GameObject>().ToList();
        GameObject rightZone = new GameObject();
        for (int i = 0; i < Continents.Count; i++)
        {
            if (Continents[i].tag == "InvestmentZone")
            {
                rightZone = Continents[i];
                break;
            }
        }

        rightZone.GetComponent<SendReceources>().ChangeAmount(amount);
    }
}
