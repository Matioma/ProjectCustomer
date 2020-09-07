using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlanetManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> planets;
    [SerializeField]
    List<GameObject> screens;

    GameObject currentPlanet;

    public void ChangePlanet(GameObject newPlanet)
    {
        currentPlanet = newPlanet;
    }

    public void ChangeUI()
    {

    }

    public void UpdateGeneral()
    {

    }
    public void UpdateFarmZone()
    {

    }

    public void UpdateWaterZone()
    {

    }

    public void UpdateMineralZone()
    {

    }

    public void UpdateResourceButtons()
    {

    }
}
