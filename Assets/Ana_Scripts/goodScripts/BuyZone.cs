using System.Collections;
using System.Collections.Generic;
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
        if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.SEEDS) >= seedsNeededToBuy &&
            GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.WATER) >= WaterNeededToBuy &&
            GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= MoneyNeededToBuy)
        {
            Debug.Log("maybe bought");
            Debug.Log(GetComponent<ReceourceZone>());

            if (GetComponent<ReceourceZone>() != null)
            {
                Debug.Log("bought");
                GetComponent<ReceourceZone>().enabled = true;
            }
            IReceourceAddition<Receources> AddResource = GetComponentInParent<IReceourceAddition<Receources>>();
            GetComponentInParent<PlanetReceources>().GetComponentInParent<UIInformation>().ZoneIsUnlocked(type);

            AddResource.AddReceource(Receources.SEEDS, - seedsNeededToBuy);
            AddResource.AddReceource(Receources.WATER, - WaterNeededToBuy);
            AddResource.AddReceource(Receources.MONEY, - MoneyNeededToBuy);


        }

    }

}
