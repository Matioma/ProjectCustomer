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
        //Debug.Log("canvasSwitcher");

        if (desiredCanvasType == CanvasType.NoZone)
        {
            canvasManager.DisableableTitleAndDescription();
        }
        else
        {
            canvasManager.EnableTitleAndDescription();
        }
        if (desiredCanvasType == CanvasType.TransportZone||desiredCanvasType==CanvasType.NoZone)
        {
            canvasManager.DisableableResourceButtons();
        }
        else
        {
            canvasManager.EnableResourceButtons();
        }

        
    }
}
