using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInformation : MonoBehaviour, IReceourceAddition<Receources, int>
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
    Canvas mainUI;
    [SerializeField]
    List<GameObject> zones;
    List<GameObject> planets;
    List<Goal> planetGoals;
    int seedConsumptionAmount;
    int seedConsumptionTime;
    int waterConsumtionAmount;
    int waterConsumtionTime;
    bool selected=false;

    Dictionary<Receources, int> resourcesNumber;

    // Start is called before the first frame update
    void Start()
    {
        resourcesNumber = new Dictionary<Receources, int>();
        resourcesNumber = GetComponentInChildren<PlanetReceources>().GetResouses();
        seedConsumptionAmount= GetComponentInChildren<PlanetReceources>().getSeedComsumptionAmount();
        seedConsumptionTime = GetComponentInChildren<PlanetReceources>().getSeedComsumptionTime();
        waterConsumtionAmount = GetComponentInChildren<PlanetReceources>().getWaterComsumptionAmount();
        waterConsumtionTime = GetComponentInChildren<PlanetReceources>().getWaterComsumptionTime(); ;
        planetGoals = GetComponent<Quest>().getGoalList();

    }


    public void AddReceource(Receources rec, int amount)
    {
        resourcesNumber[rec] += amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons();
        }
    }

    public void ChangeConsumptionAmountSeeds(int amount)
    {
        seedConsumptionAmount += amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
    public void ChangeConsumptionTimeSeeds(int amount)
    {
        seedConsumptionTime += amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
    public void ChangeConsumptionAmountWater(int amount)
    {
        waterConsumtionAmount += amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
        }
    }
    public void ChangeConsumptionTimeWater(int amount)
    {
        waterConsumtionTime += amount;
        if (selected)
        {
            mainUI.GetComponent<UIPlanetManager>().UpdateResourceButtons(); // Replace
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
