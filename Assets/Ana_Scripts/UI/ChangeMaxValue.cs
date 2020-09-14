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
        var slider = GetComponent<Slider>();
        slider.maxValue = 1;
        rec = Receources.ALL;
    }


    public void ChangeRec(int i)
    {
        switch (i)
        {
            case 1:
                rec = Receources.SEEDS;
                break;
            case 2:
                rec = Receources.WATER;
                break;
            case 3:
                rec = Receources.MONEY;
                break;
        }
    }

}
