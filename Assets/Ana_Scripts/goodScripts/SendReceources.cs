﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendReceources : MonoBehaviour
{
    Receources typeOfReceurce=Receources.SEEDS;
    int amount = 10;
    string destination="planetB";

    public void ChangeTypeOfReceource(Receources newReceource)
    {
        typeOfReceurce = newReceource;
    }
    public void ChangeAmount(int newAmount)
    {
        amount = newAmount;
    }
    public void ChangeDestination(string newName)
    {
        destination = newName;
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