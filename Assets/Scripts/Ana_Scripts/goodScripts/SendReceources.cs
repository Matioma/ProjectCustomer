using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendReceources : MonoBehaviour
{
    Receources typeOfReceurce=Receources.SEEDS;
    float amount = 0;

    [SerializeField]
    GameObject planetToSend;

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

    public void ChangeAmount(float newAmount)
    {
        amount = newAmount;
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
            //Notify SpaceShipManager to send a ship
            SpaceShipManager.Instance.SendShip(currentPlanet.GetComponentInParent<Planet>(), planetToSend.GetComponentInParent<Planet>(), typeOfReceurce, (int)amount);
            currentPlanet.GetComponent<IReceourceAddition<Receources>>().AddReceource(typeOfReceurce, (int)(-amount));
        }
    }
}
