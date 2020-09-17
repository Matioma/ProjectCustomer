using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System.Text;
using TMPro;

public enum PlanetType
{
    Planet1,
    Planet2,
    Planet3,
    Planet4,
    Planet5,
    NoPlanet
}


public class CanvasPlanetManager : MonoBehaviour
{
    List<PlanetController> canvasControllerList;
    PlanetController lastActiveCanvs;
    private void Awake()
    {
        canvasControllerList = GetComponentsInChildren<PlanetController>().ToList();
        foreach (PlanetController item in canvasControllerList)
        {
            item.gameObject.SetActive(false);
        }
        SwitchCanvas(PlanetType.NoPlanet);
    }

    public void SwitchCanvas(PlanetType _type)
    {
        if (lastActiveCanvs != null)
        {
            lastActiveCanvs.gameObject.SetActive(false);
        }
        PlanetController desiredScreen = canvasControllerList.Find(x => x.type == _type);
        if (desiredScreen != null)
        {
            desiredScreen.gameObject.SetActive(true);
            lastActiveCanvs = desiredScreen;
        }
    }
}
