using System;
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

    public event Action OnTryUpgradeWithoutMoney;



    public event Action OnZoneUpgrade;
    public void Buy()
    {
        if (upgradeIndex < upgrades.Length)
        {
            if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= upgrades[upgradeIndex].price)
            {
                Debug.Log(" listeners");
                if (upgradeIndex < upgrades.Length - 1)
                {
                    GetComponent<ReceourceZone>().ChangeProductivityNumber(upgrades[upgradeIndex].productivityIncrease, upgrades[upgradeIndex + 1].description);
                }
                else
                {
                    GetComponent<ReceourceZone>().ChangeProductivityNumber(upgrades[upgradeIndex].productivityIncrease, "Maximum level reached");
                }
                GetComponentInParent<PlanetReceources>().AddReceource(Receources.MONEY, -upgrades[upgradeIndex].price);
                upgradeIndex++;
                OnZoneUpgrade?.Invoke();
            }
            else {
                OnTryUpgradeWithoutMoney?.Invoke();
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
        //Debug.Log(upgradeIndex);
        if (upgradeIndex <= upgrades.Length-1)
        {
            return upgrades[upgradeIndex].description;
        }
        return null;
    }
}
