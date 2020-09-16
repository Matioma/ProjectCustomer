using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

public class PlanetReceources : MonoBehaviour, IReceourceAddition<Receources>, IEnablable<Receources>
{
    [SerializeField]
    int seedConsumptionAmountPerPerson = 1;
    [SerializeField]
    int seedConsumptionTime = 10;
    [SerializeField]
    int waterConsumtionAmountPerSeed = 1;
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
    [SerializeField]
    int birthRateNumber = 10;
    [SerializeField]
    int birthRateTime = 10;
    [System.Serializable]
    public class Rec
    {
        public Receources type;
        public int amount;
    }
    [SerializeField]
    List<Rec> resouces;



    float waterTimer;
    float seedTimer;
    [SerializeField]
    float birthRateTimer;
    [SerializeField]
    float hungerTimer;
    [SerializeField]
    float deathTimer;
    [SerializeField]
    int peopleToDie;
    [SerializeField]
    int deathRate;
    [SerializeField]
    int seedConsumptionAmount;

    Dictionary<Receources, int> receourcesNumber;

    bool isWaterConsuming = false;
    bool isFarmZoneBought = false;

    UIInformation info;


    public float GetHungerFractionLeft()
    {
        return hungerTimer / hungerWarningTimer;
    }


    public event Action OnPeopleStartLackFood;
    public event Action OnPeopleStopLackFood;
    public event Action OnPeopleStartDying;
    public event Action OnPeopleStopDying;


    private bool peopleLackFood = false;
    private bool peopleAreDying = false;
    private bool PeopleLackFood
    {
        get { return peopleLackFood; }
        set
        {
            if (value != peopleLackFood)
            {
                //No food
                if (value)
                {
                    OnPeopleStartLackFood?.Invoke();
                }
                //Enough Food
                else
                {
                    //Stop invoke method that people no longer Die
                    if (peopleAreDying) OnPeopleStopDying?.Invoke();
                    OnPeopleStopLackFood?.Invoke();
                }
                peopleLackFood = value;
            }
        }
    }

    private bool PeopleAreDying
    {
        get
        {
            return peopleAreDying;
        }
        set
        {
            //if value changes
            if (value != PeopleAreDying)
            {
                //If people dying
                if (!value)
                {
                    OnPeopleStopDying?.Invoke();
                }
                // If people no longer die
                else
                {
                    OnPeopleStartDying?.Invoke();
                }
                peopleAreDying = value;
            }
        }
    }





    public Dictionary<Receources, int> GetResouses()
    {
        return receourcesNumber;
    }

    public void OnValidate()
    {
        calculateConsumptionSeedAmount();
    }

    void Awake()
    {
        receourcesNumber = new Dictionary<Receources, int>();
        receourcesNumber.Add(Receources.MONEY, 0);
        receourcesNumber.Add(Receources.SEEDS, 0);
        receourcesNumber.Add(Receources.WATER, 0);
        for (int i = 0; i < resouces.Count; i++)
        {
            receourcesNumber[resouces[i].type] = resouces[i].amount;
        }
        seedTimer = seedConsumptionTime;
        waterTimer = waterConsumtionTime;
        birthRateTimer = birthRateTime;
        hungerTimer = hungerWarningTimer;
        deathTimer = peopleDeathTimer;
        info = GetComponentInParent<UIInformation>();
    }
    int initialFoodProd;
    void Start()
    {
        
        calculateConsumptionSeedAmount();
        
        initialFoodProd = info.getSeedProductionAmount();
        calculateConsumptionWaterAmount();
    }
    void calculateConsumptionSeedAmount()
    {
        seedConsumptionAmount = population * seedConsumptionAmountPerPerson;
        if (info != null)
        {
            info.ChangeConsumptionAmountSeeds(seedConsumptionAmount);
        }
        else
        {
           // Debug.Log("UIInformation is null");
        }
    }

    public void calculateConsumptionWaterAmount()
    {
        Debug.Log("water consumption change");
        if (info != null)
        {
            var productivity = info.getSeedProductionAmount();
            if (initialFoodProd != 0)
                waterConsumtionAmount = (productivity / initialFoodProd) * waterConsumtionAmountPerSeed;
            info.ChangeConsumptionAmountWater(waterConsumtionAmount);
            Debug.Log("current Productivity " + productivity);
            Debug.Log("initial Productivity " + initialFoodProd);
            Debug.Log("water consumprion per seed " + waterConsumtionAmountPerSeed);
            Debug.Log("new water consumption " + waterConsumtionAmount);
        }
        else Debug.Log("no change");
    }

    bool isEnoughReceourse(Receources type)
    {
        if (receourcesNumber[type] > 0) return true;
        return false;
    }


    public void AddReceource(Receources rec, int amount)
    {
        if (amount == 0)
        {
            return;
        }
       // Debug.Log("method amount " + amount);
        receourcesNumber[rec] += amount;
        
        var addition = GetComponentInParent<UIInformation>();
        if (addition == null)
        {
            
            Debug.LogWarning(transform.name + " planet resources resources has no UIINFORMATION component");
        }
        else
        {
            addition.AddReceource(rec, amount);
        }
        //if (Receources.SEEDS == rec)
       // {
          //  Debug.Log("newSeeds " + receourcesNumber[rec]);
        //}

 

        //Debug.Log("newSeeds " + receourcesNumber[rec]);

        


 
    }



    public int GetReceouceNumber(Receources type)
    {
        return receourcesNumber[type];
    }
    void FixedUpdate()
    {
        //Debug.Log("seeds before check: " + receourcesNumber[Receources.SEEDS]);
       // Debug.Log("consumption " + seedConsumptionAmount);
        seedConsumption();
       //Debug.Log("seeds after check: " + receourcesNumber[Receources.SEEDS]);
        //Debug.Log("consumption " + seedConsumptionAmount);
        if (isWaterConsuming == true)
        {
            waterConsumption();
        }
        if (isFarmZoneBought == true)
        {
            checkFarmZoneWorking();
        }
        CheckHunger();
        BirthRate();
    }

    void BirthRate()
    {
        if (birthRateTimer < 0)
        {
            population += birthRateNumber;
            birthRateTimer = birthRateTime;
            GetComponentInParent<UIInformation>().ChangePopulationNumber(population);
            calculateConsumptionSeedAmount();
        }
        else
        {
            birthRateTimer -= GlobalTimer.Instance.DeltaTime;
        }
    }
    void CheckHunger()
    {
        if (receourcesNumber[Receources.SEEDS] < seedConsumptionAmount)
        {
            PeopleLackFood = true;
            if (hungerTimer < 0)
            {
                PeopleAreDying = true;
                if (deathTimer > 0)
                {
                    peopleToDie = (seedConsumptionAmount - receourcesNumber[Receources.SEEDS]) / seedConsumptionAmountPerPerson;
                    deathRate = (peopleToDie * deathRateForTimer) / peopleDeathTimer;
                   // Debug.Log("seed consumprion "+seedConsumptionAmount);
                   // Debug.Log("current seeds "+receourcesNumber[Receources.SEEDS]);
                   // Debug.Log("hungry people "+peopleToDie);
                   // Debug.Log("death rate " + deathRate);
                    GetComponentInParent<UIInformation>().ChangeHungryPeople(peopleToDie);
                    GetComponentInParent<UIInformation>().ChangeDeathRateNumber(deathRate);
                    if (deathTimer % deathRateForTimer == 0)
                    {
                      //  Debug.Log("old population " + population);
                        population -= deathRate;
                      //  Debug.Log("new population " + population);
                        GetComponentInParent<UIInformation>().ChangePopulationNumber(population);
                        calculateConsumptionSeedAmount();
                    }
                    deathTimer -= GlobalTimer.Instance.DeltaTime;
                }
                else
                {
                    population = 0;
                    GetComponentInParent<UIInformation>().ChangePopulationNumber(population);
                    calculateConsumptionSeedAmount();
                }
            }
            else
            {
                hungerTimer -= GlobalTimer.Instance.DeltaTime;
            }
        }
        else
        {
            PeopleLackFood = false;
            PeopleAreDying = false;
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
       // Debug.Log("water consumption starts");
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
       // Debug.Log("water consiming "+ waterConsumtionAmount);
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
            waterTimer -= GlobalTimer.Instance.DeltaTime;
        }
    }

    private void seedConsumption()
    {
        if (seedTimer < 0 && receourcesNumber[Receources.SEEDS] > 0)
        {
            if (receourcesNumber[Receources.SEEDS] > seedConsumptionAmount)
            {
               // Debug.Log("seed before decrease " + receourcesNumber[Receources.SEEDS]);
                AddReceource(Receources.SEEDS, -seedConsumptionAmount);
                //Debug.Log("seed after decrease " + receourcesNumber[Receources.SEEDS]);
            }
            else
            {
                int currentAmount = receourcesNumber[Receources.SEEDS];
                AddReceource(Receources.SEEDS, -currentAmount);
            }
            seedTimer = seedConsumptionTime;
            
        }
        else
        {
            seedTimer -= GlobalTimer.Instance.DeltaTime;
        }
       // Debug.Log("seed during check " + receourcesNumber[Receources.SEEDS]);
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
        addition.ChangeConsumptionAmountSeeds(amount);
    }
    public void ChangeConsumptionTimeSeeds(int amount)
    {
        seedConsumptionTime += amount;
        var addition = GetComponentInParent<UIInformation>();
        addition.ChangeConsumptionTimeSeeds(amount);
    }
    public void ChangeConsumptionAmountWater(int amount)
    {
        waterConsumtionAmount += amount;
        var addition = GetComponentInParent<UIInformation>();
        addition.ChangeConsumptionAmountWater(amount);
    }
    public void ChangeConsumptionTimeWater(int amount)
    {
        waterConsumtionTime += amount;
        var addition = GetComponentInParent<UIInformation>();
        addition.ChangeConsumptionTimeWater(amount);
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

    public int getPopulation()
    {
        return population;
    }
}


