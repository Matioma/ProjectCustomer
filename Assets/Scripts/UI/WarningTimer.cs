using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WarningTimer : MonoBehaviour
{
    float progress;
    public float Value{
        get{
            return progress;
        }
        set{
            if (value != progress)
            {
                progress = value;
                SetValue(progress);
            }
        }
    }

    PlanetReceources planetReceources;


    private void Start()
    {
        planetReceources = GetComponentInParent<Planet>()?.GetComponentInChildren<PlanetReceources>();
        
    }
    void Update()
    {
        SetValue(planetReceources.GetHungerFractionLeft());
    }
    void SetValue(float fraction) {
        GetComponent<Image>().fillAmount = fraction;
    
    }
}
