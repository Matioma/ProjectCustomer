using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetReceources : MonoBehaviour, IReceourceAddition<Receources,int>, IEnablable<Receources>
{
    [SerializeField]
    int moneynumber = 100;
    [SerializeField]
    int seednumber = 100;
    [SerializeField]
    int waternumber = 100;
    [SerializeField]
    int seedConsumptionAmount = 1;
    [SerializeField]
    int seedConsumptionTime = 10;
    [SerializeField]
    int waterConsumtionAmount = 1;
    [SerializeField]
    int waterConsumtionTime = 10;
    float waterTimer;
    float seedTimer;
    Dictionary<Receources, int> receourcesNumber;

    void Start()
    {
        receourcesNumber = new Dictionary<Receources, int>();
        receourcesNumber.Add(Receources.MONEY, moneynumber);
        receourcesNumber.Add(Receources.SEEDS, seednumber);
        receourcesNumber.Add(Receources.WATER, waternumber);
        seedTimer = seedConsumptionTime;
        waterTimer = waterConsumtionAmount;
    }

    bool isEnoughReceourse(Receources type)
    {
        if (receourcesNumber[type] > 0) return true;
        return false;
    }


    public void AddReceource(Receources rec, int amount)
    {
        receourcesNumber[rec]+=amount;
        Debug.Log(rec+"   "+ receourcesNumber[rec]);

    }

    public int GetReceouceNumber(Receources type)
    {
        return receourcesNumber[type];
    }
    void Update()
    {
        seedConsumption();
        waterConsumption();
        //Debug.Log("water: " + receourcesNumber[Receources.WATER]);
       // Debug.Log("money: " + receourcesNumber[Receources.MONEY]);
    }

    private void waterConsumption()
    {
        if (waterTimer < 0 && receourcesNumber[Receources.WATER] > 0)
        {
            if (receourcesNumber[Receources.WATER] > waterConsumtionAmount)
            {
                AddReceource(Receources.WATER, -waterConsumtionAmount);
            }
            else
            {
                AddReceource(Receources.WATER, -receourcesNumber[Receources.WATER]);
            }
            waterTimer = waterConsumtionTime;
        }
        else
        {
            waterTimer -= Time.fixedDeltaTime;
        }
    }

    private void seedConsumption()
    {
        if (seedTimer < 0 && receourcesNumber[Receources.SEEDS] > 0)
        {
            if (receourcesNumber[Receources.SEEDS] > seedConsumptionAmount)
            {
                AddReceource(Receources.SEEDS, -seedConsumptionAmount);
            }
            else
            {
                AddReceource(Receources.SEEDS, -receourcesNumber[Receources.SEEDS]);
            }
            seedTimer = seedConsumptionTime;
        }
        else
        {
            seedTimer -= Time.fixedDeltaTime;
        }
    }

    void conditionsForZones()
    {

    }

    public void Enable(Receources rec)
    {
        if (rec == Receources.ALL)
        {
            this.enabled = true;
        }
    }

    public void Disable(Receources rec)
    {
        if (rec == Receources.ALL)
        {
            this.enabled = false;
        }
    }
}
