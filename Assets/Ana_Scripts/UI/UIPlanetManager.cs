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

    GameObject currentPlanet;

    public void ChangePlanet(GameObject newPlanet)
    {
        currentPlanet = newPlanet;
    }

    public GameObject GetCurrentPlanet()
    {
        return currentPlanet;
    }


    public void InitializeGeneral(int populationNumber, int hungryPeopleNumber,int deathRateNumber,int deathRateTime, int birthRateNumber, int birthRateTime)
    {
        UIGeneral.GetComponent<GeneralZoneUpdater>().Initialize( populationNumber,  hungryPeopleNumber,  deathRateNumber,  deathRateTime,  birthRateNumber,  birthRateTime);
    }
    public void InitializeFarmZone(bool isZoneUnlocked, int productivityNumber,int productivityTime, int consumptionWaterNumber, int consumptionWaterTime)
    {

    }

    public void InitializeWaterZone(bool isZoneUnlocked, int productivityNumber, int productivityTime)
    {

    }

    public void InitializeMineralZone(bool isZoneUnlocked, int productivityNumber, int productivityTime)
    {

    }
    public void InitializeInvestmentZone(bool isZoneUnlocked, GameObject Farm, GameObject Water, GameObject Mine)
    {

    }
    public void InitializeTransportZone(GameObject IndustrialZone)
    {

    }

    public void UpdateQuestes()
    {

    }
    public void UpdatePopulationNumber(int newNumber)
    {

    }
    public void UpdateHungryPeople(int newNumber)
    {

    }
    public void UpdateDeathRate(int newRateNumber, int newRateTime)
    {

    }
    public void UpdateBirthRate(int newRateNumber, int newRateTime)
    {

    }
    public void UpdateResourceButtons(Receources rec, int amount)
    {
       // if (ResouceButtons.activeSelf)
       // {
            UIResouceButtons.GetComponent<ResourcesButtonsUpdater>().ChangeAmount(rec, amount);
        UITransportZone.GetComponentInChildren<ChangeMaxValue>().ChangeValue(rec,amount);
       // }
    }
    public void UpdateSeedConsumption(int newConsumption)
    {

    }
    public void UpdateWaterConsumption(int newConsumption)
    {

    }
    public void UpdateSeedProductivity(int newProductivity)
    {

    }
    public void UpdateWaterProductivity(int newProductivity)
    {

    }
    public void UpdateMoneyProductivity(int newProductivity)
    {

    }
    public void UpdateUpgrades()
    {

    }


}
