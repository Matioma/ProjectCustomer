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
    GameObject Farm;
    public void Initialize(bool isZoneUnlocked, int productivityNumber, int productivityTime, int consumptionWaterNumber, int consumptionWaterTime, GameObject farm)
    {
        Farm = farm;
        if (isZoneUnlocked == true)
        {
            unlockZoneButton.gameObject.SetActive(false);
            UIZoneUnlocked.SetActive(true);
            UpdateProductionRate( productivityNumber,  productivityTime);
            UpdateConsumptionRate( consumptionWaterNumber,  consumptionWaterTime);
        }
        else
        {
            unlockZoneButton.gameObject.SetActive(true);
            UIZoneUnlocked.SetActive(false);
            UpdateButton();
        }
    }

    public void UpdateButton()
    {
        unlockZoneButton.onClick.RemoveAllListeners();
        unlockZoneButton.onClick.AddListener(OnBuyZone);
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
        productionRate.text = productivityNumber.ToString() + "/" + productivityTime.ToString();
    }
    public void UpdateConsumptionRate(int consumptionWaterNumber, int consumptionWaterTime)
    {
        consumptionRateWater.text = consumptionWaterNumber.ToString() + "/" + consumptionWaterTime.ToString();
    }
}
