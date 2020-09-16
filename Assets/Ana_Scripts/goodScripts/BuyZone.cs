using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class BuyZone : MonoBehaviour
{
    [SerializeField]
    int seedsNeededToBuy = 10;
    [SerializeField]
    int WaterNeededToBuy = 10;
    [SerializeField]
    int MoneyNeededToBuy = 10;
    [SerializeField]
    Receources type;
    //[SerializeField]
    //GameObject buyButton;

    public void Buy()
    {
        Debug.Log("bought?????");
        if (ConditionsToBuy())
        {
            //Debug.Log("maybe bought");
            //Debug.Log(GetComponent<ReceourceZone>());

            if (GetComponent<ReceourceZone>() != null)
            {
                //Debug.Log("bought");
                GetComponent<ReceourceZone>().enabled = true;
            }
            IReceourceAddition<Receources> AddResource = GetComponentInParent<IReceourceAddition<Receources>>();
            Debug.Log("prevous status "+ GetComponentInParent<PlanetReceources>().GetComponentInParent<UIInformation>().GetIsZoneUnlocked(type));
            GetComponentInParent<PlanetReceources>().GetComponentInParent<UIInformation>().ZoneIsUnlocked(type);
            Debug.Log("current status " + GetComponentInParent<PlanetReceources>().GetComponentInParent<UIInformation>().GetIsZoneUnlocked(type));


            AddResource.AddReceource(Receources.SEEDS, - seedsNeededToBuy);
            AddResource.AddReceource(Receources.WATER, - WaterNeededToBuy);
            AddResource.AddReceource(Receources.MONEY, - MoneyNeededToBuy);


        }
        else
        {
            Debug.Log("not bought");
        }

    }

    public bool ConditionsToBuy()
    {
        if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.SEEDS) >= seedsNeededToBuy &&
            GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.WATER) >= WaterNeededToBuy &&
            GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= MoneyNeededToBuy)
        {
            return true;
        }
        return false;
    }
    

}
