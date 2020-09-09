using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlanetReceources : MonoBehaviour, IReceourceAddition<Receources,int>, IEnablable<Receources>
{
    //[SerializeField]
    //int moneynumber = 100;
    //[SerializeField]
    //int seednumber = 100;
    //[SerializeField]
    //int waternumber = 100;

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




    [System.Serializable]
    public class Rec
    {
        public Receources type;
        public int amount;
    }
    [SerializeField]
    List<Rec> recs;
   
    public Dictionary<Receources,int> GetResouses()
    {
        return receourcesNumber;
    }

    void Awake()
    {
        receourcesNumber = new Dictionary<Receources, int>();
        receourcesNumber.Add(Receources.MONEY, 0);
        receourcesNumber.Add(Receources.SEEDS, 0);
        receourcesNumber.Add(Receources.WATER, 0);
        for (int i = 0; i < recs.Count; i++)
        {
            receourcesNumber[recs[i].type]= recs[i].amount;
        }


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
        if (amount == 0) {
            return;
        }
        receourcesNumber[rec]+=amount;
        var addition = GetComponentInParent<UIInformation>();
        if (addition == null) {
            Debug.LogWarning(transform.name + " planet resources resources has no UIINFORMATION component");
        }

        addition?.AddReceource(rec, amount);
    }



    public int GetReceouceNumber(Receources type)
    {
        return receourcesNumber[type];
    }
    void Update()
    {
        seedConsumption();
        waterConsumption();
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

    public void ChangeConsumptionAmountSeeds(int amount)
    {
        seedConsumptionAmount += amount;
        var addition = GetComponentInParent<UIInformation>();
        addition.ChangeConsumptionAmountSeeds( amount);
    }
    public void ChangeConsumptionTimeSeeds(int amount)
    {
        seedConsumptionTime += amount;
        var addition = GetComponentInParent<UIInformation>();
        addition.ChangeConsumptionTimeSeeds( amount);
    }
    public void ChangeConsumptionAmountWater(int amount)
    {
        waterConsumtionAmount += amount;
        var addition = GetComponentInParent<UIInformation>();
        addition.ChangeConsumptionAmountWater( amount);
    }
    public void ChangeConsumptionTimeWater(int amount)
    {
        waterConsumtionTime += amount;
        var addition = GetComponentInParent<UIInformation>();
        addition.ChangeConsumptionTimeWater( amount);
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
}
