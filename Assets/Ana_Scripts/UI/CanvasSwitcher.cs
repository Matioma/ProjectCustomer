using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;
    [SerializeField]
    CanvasManager canvasManager;


    public void OnScreenChange()
    {
        if (canvasManager == null ) {
            return;
        }
        canvasManager.SwitchCanvas(desiredCanvasType);
        if(desiredCanvasType== CanvasType.InvestmentZone|| desiredCanvasType == CanvasType.TransportZone)
        {
            canvasManager.DisableableResourceButtons();
        }
        else
        {
            canvasManager.EnableResourceButtons();
        }
    }
}
