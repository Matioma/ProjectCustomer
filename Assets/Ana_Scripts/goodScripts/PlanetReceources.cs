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
    int maxPopulation = 10;
    [SerializeField]
    int hungerWarningTimer = 10;
    [SerializeField]
    int peopleDeathTimer = 10;
    [SerializeField]
    int deathRateInterval = 10;
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
    int hungryPeople;
    public int GetHungryPeople() {
        return hungryPeople;
    }

    [SerializeField]
    float deathRate;
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



    public int GetRes(Receources type)
    {
        for (int i = 0; i < resouces.Count; i++)
        {
            if (resouces[i].type == type)
            {
                return resouces[i].amount;
            }
        }
        return 0;

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
        death = deathRateInterval;

    }
    int initialFoodProd;
    void Start()
    {
        info = GetComponentInParent<UIInformation>();
        if (info != null)
        {


            calculateConsumptionSeedAmount();
            initialFoodProd = info.getSeedProductionAmount();
            calculateConsumptionWaterAmount();
        }
    }
    void calculateConsumptionSeedAmount()
    {
        seedConsumptionAmount = population * seedConsumptionAmountPerPerson;
        if (info != null)
        {
            info.ChangeConsumptionAmountSeeds(seedConsumptionAmount);
        }
    }

    public void calculateConsumptionWaterAmount()
    {
        if (info != null)
        {
            var productivity = info.getSeedProductionAmount();
            if (initialFoodProd != 0)
                waterConsumtionAmount = (productivity / initialFoodProd) * waterConsumtionAmountPerSeed;
            info.ChangeConsumptionAmountWater(waterConsumtionAmount);
        }
    }

    public void AddReceource(Receources rec, int amount)
    {
       //if (amount == 0)
        //{
         //   return;
       // }
        receourcesNumber[rec] += amount;

        var addition = GetComponentInParent<UIInformation>();
        if (addition != null)
        {
            addition.AddReceource(rec, amount);
        }

        if (rec == Receources.SEEDS)
        {
            Debug.Log("seeds addition "+receourcesNumber[Receources.SEEDS]);
            Debug.Log(" addition " + amount);
            Debug.Log(" seed consumption " + seedConsumptionAmount);
        }
    }



    public int GetReceouceNumber(Receources type)
    {
        return receourcesNumber[type];
    }
    void FixedUpdate()
    {
       // Debug.Log(receourcesNumber[Receources.SEEDS]);
        seedConsumption();
        if (isWaterConsuming == true)
        {
            waterConsumption();
        }
        if (isFarmZoneBought == true)
        {
            checkFarmZoneWorking();
        }
        CheckHunger();
        if (population <= maxPopulation)
        {
            BirthRate();

        }
    }

    void BirthRate()
    {
        if (birthRateTimer < 0)
        {
            population += birthRateNumber;
            birthRateTimer = birthRateTime;
            if (info != null)
            {
                GetComponentInParent<UIInformation>().ChangePopulationNumber(population);
            }
            calculateConsumptionSeedAmount();
        }
        else
        {
            birthRateTimer -= GlobalTimer.Instance.DeltaTime;
        }
    }
    float death;
    void CheckHunger()
    {
        if (receourcesNumber[Receources.SEEDS] < seedConsumptionAmount)
        {
            PeopleLackFood = true;
            hungryPeople = (seedConsumptionAmount - receourcesNumber[Receources.SEEDS]) / seedConsumptionAmountPerPerson;
            if (info != null)
            {
                GetComponentInParent<UIInformation>().ChangeHungryPeople(hungryPeople);
            }
            if (hungerTimer < 0)
            {
                PeopleAreDying = true;
                if (deathTimer > 0.5f)
                {
                    deathRate = ((float)hungryPeople*(float)deathRateInterval)/deathTimer;
                    deathRate = Mathf.Ceil(deathRate);
                    if (info != null)
                    {
                        GetComponentInParent<UIInformation>().ChangeDeathRateNumber((int)deathRate);
                    }

                    if (death < 0)
                    {
                        if (population > deathRate)
                        {
                            population -= (int)deathRate;
                        }
                        else
                        {
                            population = 0;
                        }
                        
                        if (info != null)
                        {
                            GetComponentInParent<UIInformation>().ChangePopulationNumber(population);
                        }
                        calculateConsumptionSeedAmount();
                        death = deathRateInterval;
                    }
                    else
                    {
                        death -= GlobalTimer.Instance.DeltaTime;
                    }
                    deathTimer -= GlobalTimer.Instance.DeltaTime;
                }
                else
                {
                    deathTimer = peopleDeathTimer;

                    Debug.Log(hungryPeople);
                    if (population > hungryPeople)
                    {
                        
                        population -= hungryPeople;
                        calculateConsumptionSeedAmount();
                        hungryPeople = 0;
                    }
                    else
                    {
                        population = 0;
                    }

                    if (info != null)
                    {
                        GetComponentInParent<UIInformation>().ChangePopulationNumber(population);
                    }
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
        hungryPeople = 0;
        deathRate = 0;
        if (info != null)
        {
            GetComponentInParent<UIInformation>().ChangeHungryPeople(hungryPeople);
            GetComponentInParent<UIInformation>().ChangeDeathRateNumber((int)deathRate);
        }
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
            waterTimer -= GlobalTimer.Instance.DeltaTime;
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
                int currentAmount = receourcesNumber[Receources.SEEDS];
                AddReceource(Receources.SEEDS, -currentAmount);
            }
            seedTimer = seedConsumptionTime;

        }
        else
        {
            seedTimer -= GlobalTimer.Instance.DeltaTime;
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

    public int getBirthRateNumber()
    {
        return birthRateNumber;
    }
    public int getBirthRateTime()
    {
        return birthRateTime;
    }

    public int getDeathRateInteval()
    {
        return deathRateInterval;
    }
}


