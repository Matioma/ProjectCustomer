using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaxValue : MonoBehaviour
{

    Receources rec;

    float seedsNumber;
    float waterNumber;
    float moneyNumber;
    public void ChangeValueWhileProducing(Receources _rec, float value)
    {
        switch (_rec)
        {
            case Receources.SEEDS:
                seedsNumber = value;
                if (rec == Receources.SEEDS)
                {
                    changeValueTo(Receources.SEEDS);
                }
                break;
            case Receources.WATER:
                waterNumber = value;
                if (rec == Receources.WATER)
                {
                    changeValueTo(Receources.WATER);
                }
                break;
            case Receources.MONEY:
                moneyNumber = value;
                if (rec == Receources.MONEY)
                {
                    changeValueTo(Receources.MONEY);
                }
                break;
        }

    }

    void changeValueTo(Receources _rec)
    {
        var slider = GetComponentInChildren<Slider>();
        Debug.Log("changeValueTo");
        switch (_rec)
        {
            case Receources.SEEDS:
                Debug.Log("changeValueTo Seeds");
                slider.maxValue = seedsNumber;
                rec = _rec;
                break;
            case Receources.WATER:
                Debug.Log("changeValueTo Water");
                slider.maxValue = waterNumber;
                rec = _rec;
                break;
            case Receources.MONEY:
                Debug.Log("changeValueTo Money");
                slider.maxValue = moneyNumber;
                rec = _rec;
                break;
        }
    }

    public void ResetValue()
    {
        var slider = GetComponentInChildren<Slider>();
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
                changeValueTo(Receources.SEEDS);
                break;
            case Receources.WATER:
                rec = Receources.WATER;
                slider.value = 0;
                changeValueTo(Receources.WATER);
                break;
            case Receources.MONEY:
                rec = Receources.MONEY;
                slider.value = 0;
                changeValueTo(Receources.MONEY);
                break;
        }
    }

    public void ResetButtons(int newSeedNumber, int newWaterNumber, int newMoneyNimber)
    {
        var slider = GetComponentInChildren<Slider>();
        slider.value = 0;

        seedsNumber = newSeedNumber;
        waterNumber = newWaterNumber;
        moneyNumber = newMoneyNimber;
    }

}
