using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerVisialization : MonoBehaviour
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
    //[SerializeField, Range(0, 1)]
    //float test;

    void Update()
    {
        //Value = test;
    }
    void SetValue(float fraction) {
        GetComponent<Image>().fillAmount = fraction;
    
    }
}
