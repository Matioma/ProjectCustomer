using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReceourceZone : MonoBehaviour
{
    [SerializeField]
    Receources typeOfReceource;
    [SerializeField]
    Receources[] receourcesToWork;
    [SerializeField]
    int productivityTime=5;
    [SerializeField]
    int productionNumber = 15;
    float timer;


    public Receources GetResourceType(){ 
        return typeOfReceource;
    }
    public int GetProductionAmount() {
        return productionNumber;
    }
    public event Action onEndProductionCycle;


    private void Awake()
    {
        this.enabled = false;
    }
    private void Start()
    {
        timer = productivityTime;
        
    }

    void FixedUpdate()
    {

        if (timer < 0)
        {
            var addition = GetComponentInParent<IReceourceAddition<Receources>>();
            addition.AddReceource(typeOfReceource, productionNumber);
            onEndProductionCycle?.Invoke();
            timer = productivityTime;
            if (typeOfReceource == Receources.SEEDS)
            {
                Debug.Log("prodNumber " + productionNumber);
            }
        }
        else
        {
            timer -= GlobalTimer.Instance.DeltaTime;
        }
    }

    public void ChangeProductivityTime(int amount)
    {
        productivityTime += amount;
    }
    public void ChangeProductivityNumber(int amount,string upgradeDescription, int price)
    {
        productionNumber += amount;
        GetComponentInParent<PlanetReceources>().GetComponentInParent<UIInformation>().ChangeProductivity(typeOfReceource, amount,upgradeDescription, price);
        if (typeOfReceource == Receources.SEEDS)
        {
            GetComponentInParent<PlanetReceources>().calculateConsumptionWaterAmount();
        }
    }

    public int GetProductivityTime()
    {
        return productivityTime;
    }
    public void Enable(Receources rec)
    {
        if (rec == typeOfReceource)
        {
            this.enabled = true;
        }
    }

    public void Disable(Receources rec)
    {
        if (rec == typeOfReceource)
        {
            this.enabled = false;
        }
    }
}
