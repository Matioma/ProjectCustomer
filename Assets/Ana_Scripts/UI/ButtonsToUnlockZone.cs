using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ButtonsToUnlockZone : MonoBehaviour
{
    [SerializeField]
    Button buyButton;
    [SerializeField]
    int zone;
    [SerializeField]
    GameObject UIToUnlock;
    GameObject planet;


    private void Start()
    {
        buyButton.onClick.AddListener(OnClickToBuy);
    }

    void OnClickToBuy()
    {
        List<GameObject> Continents = planet.GetComponentsInChildren<GameObject>().ToList();
        GameObject rightZone = new GameObject(); 
        switch (zone)
        {
            case 0:
                for (int i = 0; i < Continents.Count; i++)
                {
                    if(Continents[i].tag=="FarmZone")
                    {
                        rightZone = Continents[i];
                        break;
                    }
                }
                break;
            case 1:
                for (int i = 0; i < Continents.Count; i++)
                {
                    if (Continents[i].tag == "WaterZone")
                    {
                        rightZone = Continents[i];
                        break;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < Continents.Count; i++)
                {
                    if (Continents[i].tag == "MineralZone")
                    {
                        rightZone = Continents[i];
                        break;
                    }
                }
                break;
            case 3:
                for (int i = 0; i < Continents.Count; i++)
                {
                    if (Continents[i].tag == "InvestmentZone")
                    {
                        rightZone = Continents[i];
                        break;
                    }
                }
                break;


        }
        if (rightZone != null)
        {
            rightZone.GetComponent<BuyZone>().Buy();
            UIToUnlock.GetComponent<ZoneEnabler>().Enable();
        }
       
    }
}
