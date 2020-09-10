﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInformation : MonoBehaviour, IReceourceAddition<Receources>
{

    [SerializeField]
    string descriptionGeneral;
    [SerializeField]
    string descriptionFarmingZone;
    [SerializeField]
    string descriptionWaterZone;
    [SerializeField]
    string descriptionMineralZone;
    [SerializeField]
    string descriptionIndZoneInvest;
    [SerializeField]
    string descriptionIndZoneTransport;
    [SerializeField]
    GameObject mainUI;
    [SerializeField]
    List<GameObject> zones;
    List<GameObject> planets;
    List<Goal> planetGoals;
    int seedConsumptionAmount;
    int seedConsumptionTime;
    int waterConsumtionAmount;
    int waterConsumtionTime;
    int seedProductionAmount;
    int seedProductionTime;
    int waterProductionAmount;
    int waterProductionTime;
    [SerializeField]
    bool selected=false;

    Dictionary<Receources, int> resourcesNumber;

    // Start is called before the first frame update
    void Start()
    {
        resourcesNumber = new Dictionary<Receources, int>();

        PlanetReceources planetReceources = GetComponentInChildren<PlanetReceources>();


        resourcesNumber = planetReceources.GetResouses();
        seedConsumptionAmount= planetReceources.getSeedComsumptionAmount();
        seedConsumptionTime = planetReceources.getSeedComsumptionTime();
        waterConsumtionAmount = planetReceources.getWaterComsumptionAmount();
        waterConsumtionTime = planetReceources.getWaterComsumptionTime(); ;
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

    public void ChangeConsumptionAmountSeeds(int amount)
    {
        seedConsumptionAmount += amount;
        if (selected)
        {
            //mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
    public void ChangeConsumptionTimeSeeds(int amount)
    {
        seedConsumptionTime += amount;
        if (selected)
        {
            //mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
    public void ChangeConsumptionAmountWater(int amount)
    {
        waterConsumtionAmount += amount;
        if (selected)
        {
           // mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
    public void ChangeConsumptionTimeWater(int amount)
    {
        waterConsumtionTime += amount;
        if (selected)
        {
           // mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
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
}
