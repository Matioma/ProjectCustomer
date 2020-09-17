using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;
    CanvasManager canvasManager;

    void Start()
    {
        canvasManager = GameObject.FindObjectOfType<CanvasManager>();
    }
    public void OnScreenChange()
    {
        if (canvasManager == null ) {
            return;
        }
        canvasManager.SwitchCanvas(desiredCanvasType);

        if (desiredCanvasType == CanvasType.NoZone|| desiredCanvasType == CanvasType.MainMenu || desiredCanvasType == CanvasType.WinScreen || desiredCanvasType == CanvasType.LoseScreen)
        {
            canvasManager.DisableableTitleAndDescription();
        }
        else
        {
            canvasManager.EnableTitleAndDescription();
        }
        if (desiredCanvasType == CanvasType.TransportZone||desiredCanvasType==CanvasType.NoZone || desiredCanvasType == CanvasType.MainMenu || desiredCanvasType == CanvasType.WinScreen || desiredCanvasType == CanvasType.LoseScreen)
        {
            canvasManager.DisableableResourceButtons();
        }
        else
        {
            canvasManager.EnableResourceButtons();
        }
    }

    public void OpenScreen(CanvasType canvasType) {
        desiredCanvasType = canvasType;
        OnScreenChange();
    }
}
