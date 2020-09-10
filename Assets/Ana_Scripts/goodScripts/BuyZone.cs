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
    GameObject buyButton;

    public void Buy()
    {

        if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.SEEDS) >= seedsNeededToBuy &&
            GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.WATER) >= WaterNeededToBuy &&
            GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= MoneyNeededToBuy)
        {
            if (GetComponent<ReceourceZone>() != null)
            {
                GetComponent<ReceourceZone>().enabled = true;
            }
            IReceourceAddition<Receources> AddResource = GetComponentInParent<IReceourceAddition<Receources>>();

            AddResource.AddReceource(Receources.SEEDS, - seedsNeededToBuy);
            AddResource.AddReceource(Receources.WATER, - WaterNeededToBuy);
            AddResource.AddReceource(Receources.MONEY, - MoneyNeededToBuy);

            //GetComponentInParent<IReceourceAddition>().AddReceource(Receources.SEEDS, -seedsNeededToBuy);
            //GetComponentInParent<IReceourceAddition>().AddReceource(Receources.WATER, -WaterNeededToBuy);
            //GetComponentInParent<IReceourceAddition>().AddReceource(Receources.MONEY, -MoneyNeededToBuy);
            buyButton.gameObject.SetActive(false);
        }

    }

}
