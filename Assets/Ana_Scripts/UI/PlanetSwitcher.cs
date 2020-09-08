using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSwitcher : MonoBehaviour
{
    public PlanetType desiredCanvasType;
    CanvasPlanetManager canvasManager;
    void Start()
    {
        canvasManager = GameObject.FindObjectOfType<CanvasPlanetManager>();
    }

    public void OnScreenChange()
    {
        if (canvasManager == null ) {
            return;
        }
        canvasManager.SwitchCanvas(desiredCanvasType);
    }
}
