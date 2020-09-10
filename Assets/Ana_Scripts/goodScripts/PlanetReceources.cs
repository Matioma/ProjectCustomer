using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlanetReceources : MonoBehaviour, IReceourceAddition<Receources>, IEnablable<Receources>
{
    //[SerializeField]
    //int moneynumber = 100;
    //[SerializeField]
    //int seednumber = 100;
    //[SerializeField]
    //int waternumber = 100;

    [SerializeField]
    int seedConsumptionAmountPerPerson = 1;
    [SerializeField]
    int seedConsumptionTime = 10;
    [SerializeField]
    int waterConsumtionAmount = 1;
    [SerializeField]
    int waterConsumtionTime = 10;
    [SerializeField]
    int population = 10;
    [SerializeField]
    int hungerWarningTimer = 10;
    [SerializeField]
    int peopleDeathTimer = 10;
    [SerializeField]
    int deathRateForTimer = 10;


    int seedConsumptionAmount;
    float waterTimer;
    float seedTimer;
    float hungerTimer;
    float deathTimer;
    Dictionary<Receources, int> receourcesNumber;

    bool isWaterConsuming = false;
    bool isFarmZoneBought = false;


    [System.Serializable]
    public class Rec
    {
        public Receources type;
        public int amount;
    }
    [SerializeField]
    List<Rec> resouces;
   
    public Dictionary<Receources,int> GetResouses()
    {
        return receourcesNumber;
    }

    public void OnValidate()
    {
        calculateConsumptionAmount();
    }

    void Awake()
    {
        receourcesNumber = new Dictionary<Receources, int>();
        receourcesNumber.Add(Receources.MONEY, 0);
        receourcesNumber.Add(Receources.SEEDS, 0);
        receourcesNumber.Add(Receources.WATER, 0);
        for (int i = 0; i < resouces.Count; i++)
        {
            receourcesNumber[resouces[i].type]= resouces[i].amount;
        }

        calculateConsumptionAmount();

        seedTimer = seedConsumptionTime;
        waterTimer = waterConsumtionTime;
        hungerTimer = hungerWarningTimer;
        deathTimer = peopleDeathTimer;
    }
    void calculateConsumptionAmount()
    {
        seedConsumptionAmount = population * seedConsumptionAmountPerPerson;
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
    void FixedUpdate()
    {
        seedConsumption();
        if (isWaterConsuming==true)
        {
            Debug.Log(isWaterConsuming);
            waterConsumption();
        }
        if(isFarmZoneBought == true)
        {
            checkFarmZoneWorking();
        }
        CheckHunger();
        //Debug.Log(isWaterConsuming);
    }

    void CheckHunger()
    {
        if (receourcesNumber[Receources.SEEDS] < seedConsumptionAmount)
        {
            if (hungerTimer < 0)
            {
                if (deathTimer > 0)
                {
                    int peopleToDie = (seedConsumptionAmount- receourcesNumber[Receources.SEEDS])/2;
                    int deathRate=(peopleToDie*deathRateForTimer)/peopleDeathTimer;

                    if (deathTimer % deathRateForTimer==0)
                    {
                        population -= deathRate;
                        calculateConsumptionAmount();
                    }
                    deathTimer -= Time.fixedDeltaTime;
                }
                else
                {
                    population = 0;
                    calculateConsumptionAmount();
                }
            }
            else
            {
                hungerTimer -= Time.fixedDeltaTime;
            }
        }
        else
        {
            resetHungerDeathTimers();
        }
    }
    public void resetHungerDeathTimers()
    {
        deathTimer = peopleDeathTimer;
        hungerTimer = hungerWarningTimer;
    }
    public void FarmZoneIsBought()
    {
        isWaterConsuming = true;
        isFarmZoneBought = true;
    }

    private void checkFarmZoneWorking()
    {
        if (receourcesNumber[Receources.WATER] < waterConsumtionAmount)
        {
            GetComponentInChildren<EnableZone>().DisableZone();
            isWaterConsuming = false;
        }
        else
        {
            GetComponentInChildren<EnableZone>().UnlockZone();
            isWaterConsuming = true;
        }
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
            if (receourcesNumber[Receources.SEEDS] > seedConsumptionAmountPerPerson)
            {
                AddReceource(Receources.SEEDS, -seedConsumptionAmountPerPerson);
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
        seedConsumptionAmountPerPerson += amount;
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
        return seedConsumptionAmountPerPerson;
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


