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
    General,
    FarmZone,
    WaterZone,
    MineralZone,
    InvestmentZone,
    TransportZone,
    MainMenu,
    WinScreen,
    LoseScreen
}


public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject resourceButtons;
    [SerializeField]
    GameObject TitleAndDescription;
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;
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
        
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }
        CanvasController desiredScreen = canvasControllerList.Find(x => x.type == _type);
        if (desiredScreen != null)
        {
            desiredScreen.gameObject.SetActive(true);
            lastActiveCanvas = desiredScreen;
        }
    }

    public void EnableResourceButtons()
    {
        //if (resourceButtons.activeSelf == false)
        //{
            resourceButtons.SetActive(true);

        //}
    }
    public void DisableableResourceButtons()
    {
        //if (resourceButtons.activeSelf == true)
        //{
            resourceButtons.SetActive(false);
       // }
    }
    public void EnableTitleAndDescription()
    {
        //if (resourceButtons.activeSelf == false)
        //{
        TitleAndDescription.SetActive(true);

        //}
    }
    public void DisableableTitleAndDescription()
    {
        //if (resourceButtons.activeSelf == true)
        //{
        TitleAndDescription.SetActive(false);
        // }
    }

    public CanvasController GetCurrentCanvas()
    {
        return lastActiveCanvas;
    }
}
