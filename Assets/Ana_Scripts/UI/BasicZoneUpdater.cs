using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicZoneUpdater : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI productionRate;
    [SerializeField]
    Button unlockZoneButton;
    [SerializeField]
    GameObject UIZoneUnlocked;
    GameObject Zone;
    public void Initialize(bool isZoneUnlocked, int productivityNumber, int productivityTime, GameObject zone)
    {
        Zone = zone;
        if (isZoneUnlocked == true)
        {
            unlockZoneButton.gameObject.SetActive(false);
            UIZoneUnlocked.SetActive(true);
            UpdateProductionRate(productivityNumber, productivityTime);
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
        if (Zone != null)
        {
            if (Zone.GetComponent<BuyZone>().ConditionsToBuy())
            {
                if (UIZoneUnlocked != null)
                {
                    UIZoneUnlocked.GetComponent<ZoneEnabler>().Enable();
                }
                unlockZoneButton.gameObject.SetActive(false);
            }
            Zone.GetComponent<BuyZone>().Buy();

        }

    }
    public void UpdateProductionRate(int productivityNumber, int productivityTime)
    {
        productionRate.text = productivityNumber.ToString() + "/" + productivityTime.ToString();
    }
}
