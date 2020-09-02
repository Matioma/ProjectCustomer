using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyZone : MonoBehaviour
{
    [SerializeField]
    int price = 10;
    [SerializeField]
    GameObject buyButton;

    public void Buy()
    {
        if (GetComponentInParent<PlanetReceources>().GetReceouceNumber(Receources.MONEY) > price)
        {
            GetComponent<ReceourceZone>().enabled = true;
            GetComponentInParent<IReceourceAddition<Receources, int>>().AddReceource(Receources.MONEY,-price);
            buyButton.SetActive(false);
        }
    }

}
