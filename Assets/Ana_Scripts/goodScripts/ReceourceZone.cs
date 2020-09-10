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
    float productivityTime=5;
    [SerializeField]
    int productionNumber = 15;
    float timer;

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
            timer = productivityTime;
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
    }

    public void ChangeProductivityTime(int amount)
    {
        productivityTime += amount;
    }
    public void ChangeProductivityNumber(int amount)
    {
        productionNumber += amount;
        GetComponentInParent<PlanetReceources>().GetComponentInParent<UIInformation>().ChangeProductivity(typeOfReceource, amount);
    }

    public int GetProductivity()
    {
        return productionNumber;
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
