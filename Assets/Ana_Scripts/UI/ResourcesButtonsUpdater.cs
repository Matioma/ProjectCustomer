using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ResourcesButtonsUpdater : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI seeds;
    [SerializeField]
    TextMeshProUGUI water;
    [SerializeField]
    TextMeshProUGUI money;
    int seedsNumber;
    int waterNumber;
    int moneyNumber;
    public void ChangeAmount(Receources rec, int amount)
    {
        switch (rec)
        {
            case Receources.SEEDS:
                seedsNumber = amount;
                seeds.text = seedsNumber.ToString();
                break;
            case Receources.WATER:
                
                waterNumber = amount;
                water.text = waterNumber.ToString();

                break;
            case Receources.MONEY:
                moneyNumber = amount;
                money.text = moneyNumber.ToString();
                break;
        }
    }

    public void ResetButtons(int newSeedNumber, int newWaterNumber, int newMoneyNimber)
    {
        seedsNumber = newSeedNumber;
        waterNumber = newWaterNumber;
        moneyNumber = newMoneyNimber;
        seeds.text = seedsNumber.ToString();
        water.text = waterNumber.ToString();
        money.text = moneyNumber.ToString();
    }
}
