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
    Receources id;
    int upgradeIndex = 0;

    public event Action OnTryUpgradeWithoutMoney;



    public event Action OnZoneUpgrade;
    public void Buy()
    {
        if (upgradeIndex < upgrades.Length)
        {
            if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= upgrades[upgradeIndex].price)
            {
                if (upgradeIndex < upgrades.Length - 1)
                {
                    GetComponent<ReceourceZone>().ChangeProductivityNumber(upgrades[upgradeIndex].productivityIncrease, upgrades[upgradeIndex + 1].description, upgrades[upgradeIndex+1].price);
                }
                else
                {
                    GetComponent<ReceourceZone>().ChangeProductivityNumber(upgrades[upgradeIndex].productivityIncrease, "Maximum level reached",0);
                }
                GetComponentInParent<PlanetReceources>().AddReceource(Receources.MONEY, -upgrades[upgradeIndex].price);
                upgradeIndex++;
                OnZoneUpgrade?.Invoke();
                
            }
            else {
                OnTryUpgradeWithoutMoney?.Invoke();
            }
        }
    }

    public string GetUpgradeText()
    {
        if (upgradeIndex <= upgrades.Length-1)
        {
            return upgrades[upgradeIndex].description;
        }
        return "Maximum level reached";
    }

    public int GetUpgradePrice()
    {
        if (upgradeIndex <= upgrades.Length - 1)
        {
            return upgrades[upgradeIndex].price;
        }
        return 0;
    }
}
