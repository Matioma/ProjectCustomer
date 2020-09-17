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
        SwitchCanvas(CanvasType.MainMenu);
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
        resourceButtons.SetActive(true);
    }
    public void DisableableResourceButtons()
    {
        resourceButtons.SetActive(false);
    }
    public void EnableTitleAndDescription()
    {
        TitleAndDescription.SetActive(true);
    }
    public void DisableableTitleAndDescription()
    {
        TitleAndDescription.SetActive(false);
    }

    public CanvasController GetCurrentCanvas()
    {
        return lastActiveCanvas;
    }
}
