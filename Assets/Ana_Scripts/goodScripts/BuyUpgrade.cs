﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [System.Serializable]
    public class Upgrades
    {
        public string description;
        public int productivityIncrease;
        public int price;
    }

    [SerializeField]
    Upgrades[] upgrades;
    [SerializeField]
    Button button;
    [SerializeField]
    Receources id;
    int upgradeIndex = 0;



    public event Action OnZoneUpgrade;
    public void Buy()
    {
        if (upgradeIndex < upgrades.Length)
        {
            if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= upgrades[upgradeIndex].price)
            {
                Debug.Log(" listeners");
                if(upgradeIndex < upgrades.Length-1)
                {
                    GetComponent<ReceourceZone>().ChangeProductivityNumber(upgrades[upgradeIndex].productivityIncrease, upgrades[upgradeIndex + 1].description);
                }
                else
                {
                    GetComponent<ReceourceZone>().ChangeProductivityNumber(upgrades[upgradeIndex].productivityIncrease, "Maximum level reached");
                }
                upgradeIndex++;
                OnZoneUpgrade?.Invoke();
            }
        }

        if (upgradeIndex >= upgrades.Length)
        {
            Debug.Log("remove listeners");
           // button.onClick.RemoveAllListeners();
            button.interactable = false;
            //var text = button.GetComponent<TextMeshProUGUI>();
           // text.text="Sold Out";
        }
    }

    public string GetUpgradeText()
    {
        return upgrades[upgradeIndex].description;
    }
}
