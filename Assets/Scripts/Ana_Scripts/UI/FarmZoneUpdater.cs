using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmZoneUpdater : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI productionRate;
    [SerializeField]
    TextMeshProUGUI consumptionRateWater;
    [SerializeField]
    Button unlockZoneButton;
    [SerializeField]
    GameObject UIZoneUnlocked;
    [SerializeField]
    TextMeshProUGUI priceToBuyZone;
    GameObject Farm;
    public void Initialize(bool isZoneUnlocked, int productivityNumber, int productivityTime, int consumptionWaterNumber, int consumptionWaterTime, GameObject farm, int price)
    {
        Farm = farm;
        if (isZoneUnlocked == true)
        {
            unlockZoneButton.gameObject.SetActive(false);
            UIZoneUnlocked.SetActive(true);
        }
        else
        {
            unlockZoneButton.gameObject.SetActive(true);
            UIZoneUnlocked.SetActive(false);
            UpdateButton(price);
        }
        UpdateProductionRate(productivityNumber, productivityTime);
        UpdateConsumptionRate(consumptionWaterNumber, consumptionWaterTime);
    }

    public void UpdateButton(int price)
    {
        unlockZoneButton.onClick.RemoveAllListeners();
        unlockZoneButton.onClick.AddListener(OnBuyZone);
        priceToBuyZone.text = "Price:     "+price.ToString();
    }

    void OnBuyZone()
    {
        if (Farm != null)
        {
            if (Farm.GetComponent<BuyZone>().ConditionsToBuy())
            {
                Farm.GetComponentInParent<PlanetReceources>().FarmZoneIsBought();
                if (UIZoneUnlocked != null)
                {
                    UIZoneUnlocked.GetComponent<ZoneEnabler>().Enable();
                }
                unlockZoneButton.gameObject.SetActive(false);
            }
            Farm.GetComponent<BuyZone>().Buy();
        }

    }
    public void UpdateProductionRate(int productivityNumber, int productivityTime)
    {
        productionRate.text = productivityNumber.ToString() + " /s ";// + productivityTime.ToString() + " s";
    }
    public void UpdateConsumptionRate(int consumptionWaterNumber, int consumptionWaterTime)
    {
        consumptionRateWater.text = consumptionWaterNumber.ToString() + " /s ";// + consumptionWaterTime.ToString() + " s";
    }
}
