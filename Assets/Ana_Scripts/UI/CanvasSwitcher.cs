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
        canvasManager.SwitchCanvas(desiredCanvasType);
    }
}
