﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInformation : MonoBehaviour, IReceourceAddition<Receources>
{

    [SerializeField]
    string planetName;
    [SerializeField]
    string planetDescription;
    [SerializeField]
    GameObject planet;
    [SerializeField]
    GameObject mainUI;
    [SerializeField]
    GameObject GeoMash;
    [SerializeField]
    GameObject Farm;
    [SerializeField]
    GameObject Water;
    [SerializeField]
    GameObject Mine;
    [SerializeField]
    GameObject Invest;


    List<Goal> planetGoals;

    int planetPopulation;
    int hungryPeople;
    int deathRateNumber;
    int deathRateTime;
    int birthRateNumber;
    int birthRateTime;

    Dictionary<Receources, int> resourcesNumber;

    int seedConsumptionAmount;
    int seedConsumptionTime;
    int waterConsumtionAmount;
    int waterConsumtionTime;

    int seedProductionAmount;
    int seedProductionTime;
    int waterProductionAmount;
    int waterProductionTime;
    int moneyProductionAmount;
    int moneyProductionTime;

    bool isFarmUnlocked = false;
    bool isWaterUnlocked = false;
    bool isMineUnlocked = false;
    bool isInvestmentUnlocked = false;

    [SerializeField]
    bool selected = false;



    // Start is called before the first frame update
    void Start()
    {
        resourcesNumber = new Dictionary<Receources, int>();

        PlanetReceources planetReceources = GetComponentInChildren<PlanetReceources>();


        resourcesNumber = planetReceources.GetResouses();

        seedConsumptionAmount = planetReceources.getSeedComsumptionAmount();
        seedConsumptionTime = planetReceources.getSeedComsumptionTime();
        waterConsumtionAmount = planetReceources.getWaterComsumptionAmount();
        waterConsumtionTime = planetReceources.getWaterComsumptionTime();

        seedProductionAmount = Farm.GetComponent<ReceourceZone>().GetProductivity();
        waterProductionAmount = Water.GetComponent<ReceourceZone>().GetProductivity();
        if (Mine != null)
            moneyProductionAmount = Mine.GetComponent<ReceourceZone>().GetProductivity();

        planetGoals = GetComponent<Quest>().getGoalList();

    }


    public void AddReceource(Receources rec, int amount)
    {
        //resourcesNumber[rec] += amount;


        //Debug.Log(selected);
        if (selected)
        {

            mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(rec, resourcesNumber[rec]);
        }
    }

    public void ChangeProductivity(Receources rec, int amount)
    {
        switch (rec)
        {
            case Receources.SEEDS:
                seedProductionAmount += amount;
                break;
            case Receources.WATER:
                waterProductionAmount += amount;
                break;
            case Receources.MONEY:
                moneyProductionAmount += amount;
                break;
        }
    }
    public int getSeedComsumptionAmount()
    {
        return seedConsumptionAmount;

    }
    public int getSeedComsumptionTime()
    {
        return seedConsumptionTime;
    }
    public int getWaterComsumptionAmount()
    {
        return waterConsumtionAmount;
    }
    public int getWaterComsumptionTime()
    {
        return waterConsumtionTime;
    }
    public int getSeedProductionAmount()
    {
        return seedProductionAmount;
    }
    public int GetReceouceNumber(Receources type)
    {
        return resourcesNumber[type];
    }

    public void PlanetIsSelected()
    {
        selected = true;
    }
    public void PlanetIsDeselected()
    {
        selected = false;
    }

    //---------------------------------------------
    //          ChangeVariables
    //---------------------------------------------


    public void InitializeUI()
    {
        mainUI.GetComponent<UIPlanetManager>().InitializeGeneral(planetPopulation, hungryPeople, deathRateNumber, deathRateTime, birthRateNumber, birthRateTime);
        if (Farm != null)
        {
            mainUI.GetComponent<UIPlanetManager>().InitializeFarmZone(isFarmUnlocked, seedProductionAmount, seedProductionTime, waterConsumtionAmount, waterConsumtionTime, Farm);
        }
        if (Water != null)
        {
            mainUI.GetComponent<UIPlanetManager>().InitializeWaterZone(isWaterUnlocked, waterProductionAmount, waterProductionTime, Water);
        }
        if (Mine != null)
        {
            mainUI.GetComponent<UIPlanetManager>().InitializeMineralZone(isMineUnlocked, moneyProductionAmount, moneyProductionTime, Mine);
        }
        if (Invest != null) 
        {
            mainUI.GetComponent<UIPlanetManager>().InitializeInvestmentZone(isInvestmentUnlocked, Farm, Water, Mine, Invest);
            mainUI.GetComponent<UIPlanetManager>().InitializeTransportZone(Invest,planet);
        }
    }
    public void ChangePopulationNumber(int amount)
    {
        planetPopulation = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdatePopulationNumber(amount); 
        }
    }
    public void ChangeHungryPeople(int amount)
    {
        hungryPeople = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateHungryPeople(amount); 
        }
    }
    public void ChangeDeathRateNumber(int amount)
    {
        deathRateNumber = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateDeathRate(deathRateNumber,deathRateTime);
        }
    }
    public void ChangeDeathRateTime(int amount)
    {
        deathRateTime = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateDeathRate(deathRateNumber, deathRateTime);
        }
    }
    public void ChangeBirthRateNumber(int amount)
    {
        birthRateNumber = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateBirthRate(birthRateNumber, birthRateTime);
        }
    }
    public void ChangeBirthRateTime(int amount)
    {
        birthRateTime = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateBirthRate(birthRateNumber, birthRateTime);
        }
    }

    public void ChangeConsumptionAmountSeeds(int amount)
    {
        seedConsumptionAmount = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateSeedConsumption(amount);
        }
    }
    public void ChangeConsumptionTimeSeeds(int amount)
    {
        seedConsumptionTime = amount;
        if (selected)
        {
            //mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
    public void ChangeConsumptionAmountWater(int amount)
    {
        waterConsumtionAmount = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateWaterConsumption(amount);
        }
    }
    public void ChangeConsumptionTimeWater(int amount)
    {
        waterConsumtionTime = amount;
        if (selected)
        {
            // mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
    public void ChangeProductionNumberSeeds(int amount)
    {
        waterConsumtionTime = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateSeedProductivity(amount);
        }
    }
    public void ChangeProductionTimeSeeds(int amount)
    {
        waterConsumtionTime = amount;
        if (selected)
        {
            //mainUI.GetComponent<UIPlanetManager>().UpdateSeedProductivity(amount);
        }
    }
    public void ChangeProductionNumberWater(int amount)
    {
        waterConsumtionTime = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateWaterProductivity(amount);
        }
    }
    public void ChangeProductionTimeWater(int amount)
    {
        waterConsumtionTime = amount;
        if (selected)
        {
            // mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
    public void ChangeProductionNumberMoney(int amount)
    {
        waterConsumtionTime = amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateMoneyProductivity(amount);
        }
    }
    public void ChangeProductionTimeMoney(int amount)
    {
        waterConsumtionTime = amount;
        if (selected)
        {
            // mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
}
