using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaxValue : MonoBehaviour
{
    public void ChangeValue(float value)
    {
        var slider = GetComponent<Slider>();
        slider.maxValue = value;
    }

    public void ResetValue()
    {
        var slider = GetComponent<Slider>();
        slider.maxValue = 1;
    }
}
