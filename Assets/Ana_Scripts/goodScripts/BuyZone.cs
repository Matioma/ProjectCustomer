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
        Debug.Log("is buying");

        if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.SEEDS) >= seedsNeededToBuy&&
            GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.WATER) >= WaterNeededToBuy &&
            GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) >= MoneyNeededToBuy)
        {
            Debug.Log("is bought");
            GetComponent<ReceourceZone>().enabled = true;
            GetComponentInParent<IReceourceAddition<Receources, int>>().AddReceource(Receources.SEEDS,-seedsNeededToBuy);
            GetComponentInParent<IReceourceAddition<Receources, int>>().AddReceource(Receources.WATER,-WaterNeededToBuy);
            GetComponentInParent<IReceourceAddition<Receources, int>>().AddReceource(Receources.MONEY,-MoneyNeededToBuy);
            buyButton.gameObject.SetActive(false);
        }
        
    }

}
