using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System.Text;
using TMPro;

public enum CanvasType
{
    NoZone,
    PlanetAGeneral,
    PlanetAFarmZone,
    PlanetAWaterZone,
    PlanetAMineralZone,
    PlanetAIndustrialZoneInvest,
    PlanetAIndustrialZoneTransport,
    PlanetBGeneral,
    PlanetBFarmZone,
    PlanetBWaterZone,
    PlanetBMineralZone,
    PlanetBIndustrialZoneInvest,
    PlanetBIndustrialZoneTransport,
    PlanetCGeneral,
    PlanetCFarmZone,
    PlanetCWaterZone,
    PlanetCMineralZone,
    PlanetCIndustrialZoneInvest,
    PlanetCIndustrialZoneTransport,
    PlanetDGeneral,
    PlanetDFarmZone,
    PlanetDWaterZone,
    PlanetDMineralZone,
    PlanetDIndustrialZoneInvest,
    PlanetDIndustrialZoneTransport,
}
public class CanvasManager : MonoBehaviour
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvs;
    private void Awake()
    {
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        foreach (CanvasController item in canvasControllerList)
        {
            item.gameObject.SetActive(false); 
        }
        SwitchCanvas(CanvasType.NoZone);
    }

    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvs != null)
        {
            lastActiveCanvs.gameObject.SetActive(false);
        }
        CanvasController desiredScreen = canvasControllerList.Find(x => x.type == _type);
        if (desiredScreen != null)
        {
            desiredScreen.gameObject.SetActive(true);
            lastActiveCanvs = desiredScreen;
        }
    }
}
