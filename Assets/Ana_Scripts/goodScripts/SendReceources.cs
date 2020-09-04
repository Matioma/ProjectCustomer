﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendReceources : MonoBehaviour
{
    Receources typeOfReceurce=Receources.SEEDS;
    int amount = 10;
    string destination="planetB";

    public void ChangeTypeOfReceource(int i)
    {
        switch (i)
        {
            case 1:
                typeOfReceurce = Receources.SEEDS;
                break;
            case 2:
                typeOfReceurce = Receources.WATER;
                break;
            case 3:
                typeOfReceurce = Receources.MONEY;
                break;
        }
    }
    public void ChangeAmount(int newAmount)
    {
        amount += newAmount;
    }
    public void ChangeDestination(int index)
    {
        switch (index)
        {
            case 0:
                destination = "planetB";
                break;
            case 1:
                Debug.Log("namechange");
                destination = "planetB";
                break;
        }
        
    }

    public void Send()
    {
        var currentPlanet = GetComponentInParent<PlanetReceources>();
        if (currentPlanet.GetReceouceNumber(typeOfReceurce) > amount)
        {
            currentPlanet.GetComponent<IReceourceAddition<Receources, int>>().AddReceource(typeOfReceurce, -amount);
            GameObject newPlanet = GameObject.Find(destination);
            newPlanet.GetComponent<IReceourceAddition<Receources, int>>().AddReceource(typeOfReceurce,amount);
        }
    }
}
