using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class UIInformation : MonoBehaviour, IReceourceAddition<Receources>
{

    [SerializeField]
    string planetName;

    public string GetPlanetName()
    {
        return planetName;
    }
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
    public int GetPopulation()
    {
        return planetPopulation;
    }

    int hungryPeople;

    public int GetHungryPeople()
    {
        return hungryPeople;
    }
    int deathRateNumber;
    int deathRateTime;
    int birthRateNumber;
    int birthRateTime;

    Dictionary<Receources, int> resourcesNumber;
    int seedNumber;
    int waterNumber;
    int moneyNumber;

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

    bool isOneUpgradeBought = false;

    // Start is called before the first frame update
    void Start()
    {
        PlanetReceources planetResources = GetComponentInChildren<PlanetReceources>();
        //resourcesNumber = new Dictionary<Receources, int>();
        // resourcesNumber.Add(Receources.MONEY, planetResources.GetResouses()[Receources.MONEY]);
        // resourcesNumber.Add(Receources.SEEDS, planetResources.GetResouses()[Receources.SEEDS]);
        // resourcesNumber.Add(Receources.WATER, planetResources.GetResouses()[Receources.WATER]);
        //seedNumber = planetResources.GetResouses()[Receources.SEEDS];
        //waterNumber = planetResources.GetResouses()[Receources.WATER];
        //moneyNumber = planetResources.GetResouses()[Receources.MONEY];

        
        //seedNumber = planetResources.GetRes(Receources.SEEDS);
        //waterNumber = planetResources.GetRes(Receources.WATER);
        //moneyNumber = planetResources.GetRes(Receources.MONEY);

        Debug.Log("seeds: "+seedNumber);
        Debug.Log("water: "+waterNumber);
        Debug.Log("money: "+moneyNumber);

    }

    void Awake()
    {
        PlanetReceources planetResources = GetComponentInChildren<PlanetReceources>();
        //resourcesNumber = new Dictionary<Receources, int>();

        seedNumber = planetResources.GetRes(Receources.SEEDS);
        waterNumber = planetResources.GetRes(Receources.WATER);
        moneyNumber = planetResources.GetRes(Receources.MONEY);

        birthRateNumber = planetResources.getBirthRateNumber();
        birthRateTime = planetResources.getBirthRateTime();
        deathRateTime = planetResources.getDeathRateInteval();

        seedConsumptionAmount = planetResources.getSeedComsumptionAmount();
        seedConsumptionTime = planetResources.getSeedComsumptionTime();

        waterConsumtionAmount = planetResources.getWaterComsumptionAmount();
        waterConsumtionTime = planetResources.getWaterComsumptionTime();

        planetPopulation = planetResources.getPopulation();

        if (Farm != null)
        {
            seedProductionAmount = Farm.GetComponent<ReceourceZone>().GetProductionAmount();
            seedProductionTime = Farm.GetComponent<ReceourceZone>().GetProductivityTime();
        }
        if (Water != null)
        {
            waterProductionAmount = Water.GetComponent<ReceourceZone>().GetProductionAmount();
            waterProductionTime = Water.GetComponent<ReceourceZone>().GetProductivityTime();
        }
        if (Mine != null)
        {
            moneyProductionAmount = Mine.GetComponent<ReceourceZone>().GetProductionAmount();
            moneyProductionTime = Mine.GetComponent<ReceourceZone>().GetProductivityTime();
        }


    }


    public void AddReceource(Receources rec, int amount)
    {
       // resourcesNumber[rec] += amount;
        switch (rec)
        {
            case Receources.SEEDS:
                seedNumber += amount;
                if (selected)
                {
                    mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(rec, seedNumber);
                }
                break;
            case Receources.WATER:
                waterNumber += amount;
                if (selected)
                {
                    mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(rec, waterNumber);
                }
                break;
            case Receources.MONEY:
                moneyNumber += amount;
                if (selected)
                {
                    mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(rec, moneyNumber);
                }
                break;

        }

        //Debug.Log(selected);
        //if (selected)
        //{
        //    mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(rec, resourcesNumber[rec]);
        //}
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
        switch (type)
        {
            case Receources.SEEDS:
                return seedNumber;
            case Receources.WATER:
                return waterNumber;
            case Receources.MONEY:
                return moneyNumber;
            default:
                return 0;

        }
       // return resourcesNumber[type];
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
        if (mainUI.GetComponent<UIPlanetManager>() != null)
        {
           // Debug.Log("Birth Rate UIInformation: " + birthRateNumber.ToString() + " / " + birthRateTime.ToString() + " s");

            mainUI.GetComponent<UIPlanetManager>().InitializeGeneral(planetPopulation, hungryPeople, deathRateNumber, deathRateTime, birthRateNumber, birthRateTime, seedConsumptionAmount, seedConsumptionTime);
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

                Debug.Log("seeds 1: " + seedNumber);
                Debug.Log("water 1: " + waterNumber);
                Debug.Log("money 1: " + moneyNumber);
                mainUI.GetComponent<UIPlanetManager>().InitializeInvestmentZone(isInvestmentUnlocked, Farm, Water, Mine, Invest, Invest.GetComponent<BuyZone>().GetPrice());
                mainUI.GetComponent<UIPlanetManager>().InitializeTransportZone(Invest, planet, seedNumber, waterNumber, moneyNumber);
                Debug.Log("init invest");
            }

            Debug.Log("init InitalizeTitleAndDescription");
            Debug.Log("seeds 2: " + seedNumber);
            Debug.Log("water 2: " + waterNumber);
            Debug.Log("money 2: " + moneyNumber);
            mainUI.GetComponent<UIPlanetManager>()?.InitializeRecourceButtons(seedNumber, waterNumber, moneyNumber);

            mainUI.GetComponent<UIPlanetManager>().InitalizeTitleAndDescription(planetName, planetDescription);
        }
        else
        {
            Debug.Log("planetManger is Null");
        }
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
            // Debug.Log("deathrateChange");
            mainUI.GetComponent<UIPlanetManager>().UpdateDeathRate(deathRateNumber, deathRateTime);
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
