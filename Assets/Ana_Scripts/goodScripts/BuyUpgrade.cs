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
    public void Buy()
    {
        if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= upgrades[upgradeIndex].price)
        {
            GetComponent<ReceourceZone>().ChangeProductivityNumber(upgrades[upgradeIndex].productivityIncrease);
            upgradeIndex++;
        }

        if (upgradeIndex >= upgrades.Length)
        {
            button.onClick.RemoveAllListeners();
            var text = button.GetComponent<TextMeshProUGUI>();
            text.text="Sold Out";
        }
    }
}
