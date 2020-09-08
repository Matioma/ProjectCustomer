using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesButtonsUpdater : MonoBehaviour
{
    [SerializeField]
    Text seeds;
    [SerializeField]
    Text water;
    [SerializeField]
    Text money;
    int seedsNumber;
    int waterNumber;
    int moneyNumber;
    public void ChangeAmount(Receources rec, int amount)
    {
        switch (rec)
        {
            case Receources.SEEDS:
                seedsNumber += amount;
                seeds.text = seedsNumber.ToString();
                break;
            case Receources.WATER:
                water.text = waterNumber.ToString();
                waterNumber += amount;
                break;
            case Receources.MONEY:
                money.text = moneyNumber.ToString();
                moneyNumber += amount;
                break;
        }
    }

    public void ResetButtons(int newSeedNumber, int newWaterNumber, int newMoneyNimber)
    {
        seedsNumber = newSeedNumber;
        waterNumber = newWaterNumber;
        moneyNumber = newMoneyNimber;
    }


}
