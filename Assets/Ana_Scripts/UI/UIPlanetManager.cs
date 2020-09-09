using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlanetManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> planets;
    [SerializeField]
    GameObject General;
    [SerializeField]
    GameObject FarmZone;
    [SerializeField]
    GameObject WaterZone;
    [SerializeField]
    GameObject MineralZone;
    [SerializeField]
    GameObject InvestmentZone;
    [SerializeField]
    GameObject TransportZone;
    [SerializeField]
    GameObject ResouceButtons;

    GameObject currentPlanet;

    public void ChangePlanet(GameObject newPlanet)
    {
        currentPlanet = newPlanet;
    }

    public GameObject GetCurrentPlanet()
    {
        return currentPlanet;
    }

    public void UpdateAllScrreens()
    {
        UpdateGeneral();
        UpdateFarmZone();
        UpdateWaterZone();
        UpdateMineralZone();
        UpdateInvestmentZone();
        UpdateTransportZone();
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
    public void UpdateInvestmentZone()
    {

    }
    public void UpdateTransportZone()
    {

    }

    public void UpdateResourceButtons(Receources rec, int amount)
    {
       // if (ResouceButtons.activeSelf)
       // {
            ResouceButtons.GetComponent<ResourcesButtonsUpdater>().ChangeAmount(rec, amount);
       // }
    }
}
