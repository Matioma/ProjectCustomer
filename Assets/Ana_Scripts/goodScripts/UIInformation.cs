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

    bool isOneUpgradeBought=false;

    // Start is called before the first frame update
    void Start()
    {
        

        PlanetReceources planetReceources = GetComponentInChildren<PlanetReceources>();
        


        seedConsumptionAmount = planetReceources.getSeedComsumptionAmount();
        seedConsumptionTime = planetReceources.getSeedComsumptionTime();
        waterConsumtionAmount = planetReceources.getWaterComsumptionAmount();
        waterConsumtionTime = planetReceources.getWaterComsumptionTime();

        planetPopulation = planetReceources.getPopulation();


        planetGoals = GetComponent<Quest>().getGoalList();


        

    }

    void Awake()
    {
        PlanetReceources planetReceources = GetComponentInChildren<PlanetReceources>();
        resourcesNumber = new Dictionary<Receources, int>(planetReceources.GetResouses());
        seedProductionAmount = Farm.GetComponent<ReceourceZone>().GetProductionAmount();
        seedProductionTime = Farm.GetComponent<ReceourceZone>().GetProductivityTime();

        waterProductionAmount = Water.GetComponent<ReceourceZone>().GetProductionAmount();
        waterProductionTime = Water.GetComponent<ReceourceZone>().GetProductivityTime();
        if (Mine != null)
        {
            moneyProductionAmount = Mine.GetComponent<ReceourceZone>().GetProductionAmount();
            moneyProductionTime = Mine.GetComponent<ReceourceZone>().GetProductivityTime();
        }
    }


    public void AddReceource(Receources rec, int amount)
    {
        resourcesNumber[rec] += amount;


        //Debug.Log(selected);
        if (selected)
        {
            //if (mainUI.GetComponent<UIPlanetManager>() == null)
            //{
            //    Debug.Log("is null");
            //}
            //else
            //{
            //    if (mainUI != null)
            //    {
                    mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(rec, resourcesNumber[rec]);
                    //Debug.Log("is not null");
                //}
            //}
            

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

    public bool GetIsOneUpgradeBought()
    {
        return isOneUpgradeBought;
    }

    public bool GetIsZoneUnlocked(Receources Id)
    {
        switch (Id)
        {
            case Receources.SEEDS:
                return isFarmUnlocked;
               // break;
            case Receources.WATER:
                return isWaterUnlocked;
               // break;
            case Receources.MONEY:
                return isMineUnlocked;
               // break;
            case Receources.INDUSTRIAL:
                return isInvestmentUnlocked;
                //break;
            default:
                return false;
                
        }
    }

    void Update()
    {
        //Debug.Log("investment Zone status " + isInvestmentUnlocked);
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
        Debug.Log("init ui");
        if (mainUI.GetComponent<UIPlanetManager>()!=null)
        {
            mainUI.GetComponent<UIPlanetManager>().InitializeGeneral(planetPopulation, hungryPeople, deathRateNumber, deathRateTime, birthRateNumber, birthRateTime,seedConsumptionAmount,seedConsumptionTime);
            if (Farm != null)
            {
                

                mainUI.GetComponent<UIPlanetManager>().InitializeFarmZone(isFarmUnlocked, seedProductionAmount, seedProductionTime, waterConsumtionAmount, waterConsumtionTime, Farm, Farm.GetComponent<BuyZone>().GetPrice());
                Debug.Log("init ui farm");
            }
            if (Water != null)
            {
                

                mainUI.GetComponent<UIPlanetManager>().InitializeWaterZone(isWaterUnlocked, waterProductionAmount, waterProductionTime, Water, Water.GetComponent<BuyZone>().GetPrice());
                Debug.Log("init water");
            }
            if (Mine != null)
            {
               

                mainUI.GetComponent<UIPlanetManager>().InitializeMineralZone(isMineUnlocked, moneyProductionAmount, moneyProductionTime, Mine, Mine.GetComponent<BuyZone>().GetPrice());
                Debug.Log("init ui mine");
            }
            if (Invest != null)
            {
               

                mainUI.GetComponent<UIPlanetManager>().InitializeInvestmentZone(isInvestmentUnlocked, Farm, Water, Mine, Invest, Invest.GetComponent<BuyZone>().GetPrice());
                mainUI.GetComponent<UIPlanetManager>().InitializeTransportZone(Invest, planet);
                Debug.Log("init invest");
            }

            Debug.Log("init InitalizeTitleAndDescription");
            mainUI.GetComponent<UIPlanetManager>()?.InitializeRecourceButtons(resourcesNumber[Receources.SEEDS], resourcesNumber[Receources.WATER], resourcesNumber[Receources.MONEY]);

            mainUI.GetComponent<UIPlanetManager>().InitalizeTitleAndDescription(planetName, planetDescription);
        }
        else
        {
            Debug.Log("planetManger is Null");
        }
    }

    public void initTest()
    {
        Debug.Log("init buttons");
        mainUI.GetComponent<UIPlanetManager>().CheckForResourceButtons();
        //Debug.Log(resourcesNumber[Receources.SEEDS] + "    " + resourcesNumber[Receources.WATER] + "    " + resourcesNumber[Receources.MONEY]);
        Debug.Log(resourcesNumber);

    }

    public void ZoneIsUnlocked(Receources Id)
    {
        switch (Id)
        {
            case Receources.SEEDS:
                isFarmUnlocked = true;
                break;
            case Receources.WATER:
                isWaterUnlocked = true;
                break;
            case Receources.MONEY:
                isMineUnlocked = true;
                break;
            case Receources.INDUSTRIAL:
                isInvestmentUnlocked = true;
                break;
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
            mainUI.GetComponent<UIPlanetManager>().UpdateSeedConsumption(seedConsumptionAmount, seedConsumptionTime);
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
            mainUI.GetComponent<UIPlanetManager>().UpdateWaterConsumption(waterConsumtionAmount, waterConsumtionTime);
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

    public void ChangeProductivity(Receources Id, int amount, string description, int price)
    {
        isOneUpgradeBought = true;
        switch (Id)
        {
            case Receources.SEEDS:
                seedProductionAmount += amount;
                if (selected)
                {
                    Debug.Log("prod time " + seedProductionAmount);
                    mainUI.GetComponent<UIPlanetManager>().UpdateSeedProductivity(seedProductionAmount, seedProductionTime);
                    mainUI.GetComponent<UIPlanetManager>().UpdateUpgrades(Id, description, price);
                }
                break;
            case Receources.WATER:
                waterProductionAmount += amount;
                if (selected)
                {
                    mainUI.GetComponent<UIPlanetManager>().UpdateWaterProductivity(waterProductionAmount, waterProductionTime);
                    mainUI.GetComponent<UIPlanetManager>().UpdateUpgrades(Id, description, price);
                }
                break;
            case Receources.MONEY:
                moneyProductionAmount += amount;
                if (selected)
                {
                    mainUI.GetComponent<UIPlanetManager>().UpdateMoneyProductivity(moneyProductionAmount, moneyProductionTime);
                    mainUI.GetComponent<UIPlanetManager>().UpdateUpgrades(Id, description, price);
                }
                break;
        }
    }

}
