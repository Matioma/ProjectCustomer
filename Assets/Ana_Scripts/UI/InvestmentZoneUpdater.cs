using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvestmentZoneUpdater : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI farmUpgradeDescription;
    [SerializeField]
    TextMeshProUGUI waterUpgradeDescription;
    [SerializeField]
    TextMeshProUGUI mineUpgradeDescription;
    [SerializeField]
    Button farmUpgradeButton;
    [SerializeField]
    Button waterUpgradeButton;
    [SerializeField]
    Button mineUpgradeButton;
    [SerializeField]
    Button unlockZoneButton;
    [SerializeField]
    GameObject UIZoneUnlocked;
    GameObject Farm;
    GameObject Water;
    GameObject Mine;
    GameObject Invest;
    public void Initialize(bool isZoneUnlocked, GameObject farm, GameObject water, GameObject mine, GameObject invest)
    {
        Farm = farm;
        Water = water;
        Mine = mine;
        Invest = invest;
        if (isZoneUnlocked == true)
        {
            unlockZoneButton.gameObject.SetActive(false);
            UIZoneUnlocked.SetActive(true);
            UpdateUI();
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
        if (Invest != null)
        {
            Invest.GetComponent<BuyZone>().Buy();
        }
        if (UIZoneUnlocked != null)
        {
            UIZoneUnlocked.GetComponent<ZoneEnabler>().Enable();
        }
        unlockZoneButton.gameObject.SetActive(false);
    }
    void UpdateUI()
    {
        if (Farm == null)
        {
            farmUpgradeDescription.gameObject.SetActive(false);
            farmUpgradeButton.gameObject.SetActive(false);
        }
        else
        {
            farmUpgradeDescription.gameObject.SetActive(true);
            farmUpgradeDescription.text = Farm.GetComponent<BuyUpgrade>().GetUpgradeText();
            farmUpgradeButton.gameObject.SetActive(true);
            farmUpgradeButton.onClick.RemoveAllListeners();
            farmUpgradeButton.onClick.AddListener(OnBuyUpgradeFarm);
        }
        if (Water == null)
        {
            waterUpgradeDescription.gameObject.SetActive(false);
            waterUpgradeButton.gameObject.SetActive(false);
        }
        else
        {
            waterUpgradeDescription.gameObject.SetActive(true);
            waterUpgradeDescription.text = Water.GetComponent<BuyUpgrade>().GetUpgradeText();
            waterUpgradeButton.gameObject.SetActive(true);
            waterUpgradeButton.onClick.RemoveAllListeners();
            waterUpgradeButton.onClick.AddListener(OnBuyUpgradeWater);
        }
        if (Mine == null)
        {
            mineUpgradeDescription.gameObject.SetActive(false);
            mineUpgradeButton.gameObject.SetActive(false);
        }
        else
        {
            mineUpgradeDescription.gameObject.SetActive(true);
            mineUpgradeDescription.text = Mine.GetComponent<BuyUpgrade>().GetUpgradeText();
            mineUpgradeButton.gameObject.SetActive(true);
            mineUpgradeButton.onClick.RemoveAllListeners();
            mineUpgradeButton.onClick.AddListener(OnBuyUpgradeMine);
        }
    }
    void OnBuyUpgradeFarm()
    {
        if (Farm != null)
        {
            Farm.GetComponent<BuyUpgrade>().Buy();
        }
    }
    void OnBuyUpgradeWater()
    {
        if (Water != null)
        {
            Water.GetComponent<BuyUpgrade>().Buy();
        }
    }
    void OnBuyUpgradeMine()
    {
        if (Mine != null)
        {
            Mine.GetComponent<BuyUpgrade>().Buy();
        }
    }

    public void UpdateUpgradeText(Receources resource, string description)
    {
        switch (resource)
        {
            case Receources.SEEDS:
                farmUpgradeDescription.text = description;
                break;
            case Receources.WATER:
                waterUpgradeDescription.text = description;
                break;
            case Receources.MONEY:
                mineUpgradeDescription.text = description;
                break;
        }
    }
}
