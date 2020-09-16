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
                if (value >= 0) {
                    progress = value;
                }
                else {
                    progress = 0;                
                }
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
        Value = planetReceources.GetHungerFractionLeft();
        Debug.LogWarning(Value);
        //SetValue(planetReceources.GetHungerFractionLeft());
    }
    void SetValue(float fraction) {
        GetComponent<Image>().fillAmount = fraction;
    
    }
}
