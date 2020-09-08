using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendReceources : MonoBehaviour
{
    Receources typeOfReceurce=Receources.SEEDS;
    int amount = 10;
    string destination="planetB";
    GameObject planetToSend;

    public void ChangeTypeOfReceource(Receources rec)
    {
        switch (rec)
        {
            case Receources.SEEDS:
                typeOfReceurce = Receources.SEEDS;
                break;
            case Receources.WATER:
                typeOfReceurce = Receources.WATER;
                break;
            case Receources.MONEY:
                typeOfReceurce = Receources.MONEY;
                break;
        }
    }
    public void ChangeAmount(int newAmount)
    {
        amount += newAmount;
    }
    public void ChangeDestination(GameObject newPlanet)
    {
        planetToSend = newPlanet;
        
    }

    public void Send()
    {
        var currentPlanet = GetComponentInParent<PlanetReceources>();
        if (currentPlanet.GetReceouceNumber(typeOfReceurce) > amount)
        {
            currentPlanet.GetComponent<IReceourceAddition<Receources, int>>().AddReceource(typeOfReceurce, -amount);
            planetToSend.GetComponent<IReceourceAddition<Receources, int>>().AddReceource(typeOfReceurce,amount);
        }
    }
}
