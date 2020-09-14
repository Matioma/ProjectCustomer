using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaxValue : MonoBehaviour
{

    Receources rec;
    public void ChangeValue(Receources _rec, float value)
    {
        if (rec == _rec)
        {
            var slider = GetComponentInChildren<Slider>();
            slider.maxValue = value;
        }

    }

    public void ResetValue()
    {
        var slider = GetComponentInChildren<Slider>();
        slider.maxValue = 1;
        slider.value = 0;
    }


    public void ChangeRec(Receources resouce)
    {
        var slider = GetComponentInChildren<Slider>();
        switch (resouce)
        {
            case Receources.SEEDS:
                rec = Receources.SEEDS;
                slider.value = 0;
                break;
            case Receources.WATER:
                rec = Receources.WATER;
                slider.value = 0;
                break;
            case Receources.MONEY:
                rec = Receources.MONEY;
                slider.value = 0;
                break;
        }
    }

}
