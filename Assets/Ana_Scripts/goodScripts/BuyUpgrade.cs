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
        public int productivityIncrease;
        public int price;
    }

    [SerializeField]
    Upgrades[] upgrades;
    [SerializeField]
    Button button;
    int upgradeIndex = 0;



    public event Action OnZoneUpgrade;
    public void Buy()
    {
        if (upgradeIndex < upgrades.Length)
        {
            if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= upgrades[upgradeIndex].price)
            {
                Debug.Log(" listeners");
                GetComponent<ReceourceZone>().ChangeProductivityNumber(upgrades[upgradeIndex].productivityIncrease);
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
}
