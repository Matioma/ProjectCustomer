using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlanetManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> planets;
    [SerializeField]
    GameObject UIGeneral;
    [SerializeField]
    GameObject UIFarmZone;
    [SerializeField]
    GameObject UIWaterZone;
    [SerializeField]
    GameObject UIMineralZone;
    [SerializeField]
    GameObject UIInvestmentZone;
    [SerializeField]
    GameObject UITransportZone;
    [SerializeField]
    GameObject UIResouceButtons;
    [SerializeField]
    GameObject UITitleAndDescription;

    GameObject currentPlanet;

    public void ChangePlanet(GameObject newPlanet)
    {
        currentPlanet = newPlanet;
    }

    public GameObject GetCurrentPlanet()
    {
        return currentPlanet;
    }


    public void InitializeGeneral(int populationNumber, int hungryPeopleNumber, int deathRateNumber, int deathRateTime, int birthRateNumber, int birthRateTime)
    {
        UIGeneral.GetComponent<GeneralZoneUpdater>().Initialize(populationNumber, hungryPeopleNumber, deathRateNumber, deathRateTime, birthRateNumber, birthRateTime);
    }
    public void InitializeFarmZone(bool isZoneUnlocked, int productivityNumber, int productivityTime, int consumptionWaterNumber, int consumptionWaterTime, GameObject Farm, int price)
    {
        UIFarmZone.GetComponent<FarmZoneUpdater>().Initialize(isZoneUnlocked, productivityNumber, productivityTime, consumptionWaterNumber, consumptionWaterTime, Farm, price);
    }

    public void InitializeWaterZone(bool isZoneUnlocked, int productivityNumber, int productivityTime, GameObject Zone, int price)
    {
        UIWaterZone.GetComponent<BasicZoneUpdater>().Initialize(isZoneUnlocked, productivityNumber, productivityTime, Zone, price);
    }

    public void InitializeMineralZone(bool isZoneUnlocked, int productivityNumber, int productivityTime, GameObject Zone, int price)
    {
        UIMineralZone.GetComponent<BasicZoneUpdater>().Initialize(isZoneUnlocked, productivityNumber, productivityTime, Zone, price);
    }
    public void InitializeInvestmentZone(bool isZoneUnlocked, GameObject Farm, GameObject Water, GameObject Mine, GameObject Invest, int price)
    {
        UIInvestmentZone.GetComponent<InvestmentZoneUpdater>().Initialize(isZoneUnlocked, Farm, Water, Mine, Invest, price);
    }
    public void InitializeTransportZone(GameObject IndustrialZone, GameObject currentPlanet)
    {
        UITransportZone.GetComponent<TransportZoneUpdater>().Initialize(IndustrialZone, currentPlanet);
    }

    public void InitializeRecourceButtons(int newSeedNumber, int newWaterNumber, int newMoneyNimber)
    {
        UIResouceButtons.GetComponent<ResourcesButtonsUpdater>().ResetButtons(newSeedNumber, newWaterNumber, newMoneyNimber);
    }

    public void InitalizeTitleAndDescription(string title, string description)
    {
        UITitleAndDescription.GetComponent<TitleAndDescriptionUpdater>().Initialize(title, description);
    }

    public void UpdateQuestes()
    {

    }
    public void UpdatePopulationNumber(int newNumber)
    {
        UIGeneral.GetComponent<GeneralZoneUpdater>().UpdatePopulationNumber(newNumber);
    }
    public void UpdateHungryPeople(int newNumber)
    {
        UIGeneral.GetComponent<GeneralZoneUpdater>().UpdateHungryPeople(newNumber);
    }
    public void UpdateDeathRate(int newRateNumber, int newRateTime)
    {
        UIGeneral.GetComponent<GeneralZoneUpdater>().UpdateDeathRate(newRateNumber, newRateTime);
    }
    public void UpdateBirthRate(int newRateNumber, int newRateTime)
    {
        UIGeneral.GetComponent<GeneralZoneUpdater>().UpdateBirthRate(newRateNumber, newRateTime);
    }
    public void UpdateResourceButtons(Receources rec, int amount)
    {
        UIResouceButtons.GetComponent<ResourcesButtonsUpdater>().ChangeAmount(rec, amount);
        UITransportZone.GetComponentInChildren<ChangeMaxValue>().ChangeValue(rec, amount);
    }
    public void UpdateSeedConsumption(int newConsumption) ///////////////// To Add
    {

    }
    public void UpdateWaterConsumption(int newConsumptionNumber, int newConsumprionTime)
    {
        UIFarmZone.GetComponent<FarmZoneUpdater>().UpdateConsumptionRate(newConsumptionNumber, newConsumprionTime);
    }
    public void UpdateSeedProductivity(int newProductivityNumber, int newProductivitytTime)
    {
        UIFarmZone.GetComponent<FarmZoneUpdater>().UpdateProductionRate(newProductivityNumber, newProductivitytTime);
    }
    public void UpdateWaterProductivity(int newProductivityNumber, int newProductivitytTime)
    {
        UIWaterZone.GetComponent<BasicZoneUpdater>().UpdateProductionRate(newProductivityNumber, newProductivitytTime);

    }
    public void UpdateMoneyProductivity(int newProductivityNumber, int newProductivitytTime)
    {
        UIMineralZone.GetComponent<BasicZoneUpdater>().UpdateProductionRate(newProductivityNumber, newProductivitytTime);

    }
    public void UpdateUpgrades(Receources resource, string description,int price)
    {
        UIInvestmentZone.GetComponent<InvestmentZoneUpdater>().UpdateUpgradeText(resource, description, price);
    }


}
