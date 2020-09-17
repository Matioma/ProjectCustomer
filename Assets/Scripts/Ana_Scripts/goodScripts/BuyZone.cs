using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class BuyZone : MonoBehaviour
{
    [SerializeField]
    int MoneyNeededToBuy = 10;
    [SerializeField]
    Receources typeOfZone;
    //[SerializeField]
    //GameObject buyButton;

    public void Buy()
    {

        if (ConditionsToBuy())
        {
            if (GetComponent<ReceourceZone>() != null)
            {
                GetComponent<ReceourceZone>().enabled = true;
            }
            IReceourceAddition<Receources> AddResource = GetComponentInParent<IReceourceAddition<Receources>>();
            GetComponentInParent<PlanetReceources>().GetComponentInParent<UIInformation>().ZoneIsUnlocked(typeOfZone);

            AddResource.AddReceource(Receources.MONEY, - MoneyNeededToBuy);


        }

    }

    public bool ConditionsToBuy()
    {
        if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= MoneyNeededToBuy)
        {
            return true;
        }
        return false;
    }

    public int GetPrice()
    {
        return MoneyNeededToBuy;
    }
    

}
