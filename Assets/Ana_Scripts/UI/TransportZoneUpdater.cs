using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportZoneUpdater : MonoBehaviour
{
    [SerializeField]
    List<GameObject> planets;
    List<GameObject> planetsIcons;
    GameObject currentPlanet;
    

    public void ChangeCurrentPlanet(GameObject newPlanet)
    {
        currentPlanet = newPlanet;
        planetsIcons = new List<GameObject>(planets);
        planetsIcons.Remove(currentPlanet);
    }
    public void UpdateRecButtons()
    {

    }

    public void ChangePlatesButtons()
    {

    }
}
