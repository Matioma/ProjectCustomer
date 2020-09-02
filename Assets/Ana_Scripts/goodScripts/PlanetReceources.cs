using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetReceources : MonoBehaviour, IReceourceAddition<Receources,int>
{
    [SerializeField]
    int moneynumber = 100;
    [SerializeField]
    int seednumber = 100;
    [SerializeField]
    int waternumber = 100;
    Dictionary<Receources, int> receourcesNumber;

    void Start()
    {
        receourcesNumber = new Dictionary<Receources, int>();
        receourcesNumber.Add(Receources.MONEY, moneynumber);
        receourcesNumber.Add(Receources.SEEDS, seednumber);
        receourcesNumber.Add(Receources.WATER, waternumber);
    }

    bool isEnoughReceourse(Receources type)
    {
        if (receourcesNumber[type] > 0) return true;
        return false;
    }


    public void AddReceource(Receources rec, int amount)
    {
        receourcesNumber[rec]+=amount;
    }
   
    public int GetReceouceNumber(Receources type)
    {
        return receourcesNumber[type];
    }
    void Update()
    {
        Debug.Log("seeds: " + receourcesNumber[Receources.SEEDS]);
        Debug.Log("water: " + receourcesNumber[Receources.WATER]);
        Debug.Log("money: " + receourcesNumber[Receources.MONEY]);
    }

}
