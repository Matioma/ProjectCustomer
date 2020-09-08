using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourceButtonsSwitcher : MonoBehaviour
{

    //[SerializeField]
    //List<Button> resourcesButtons;

    private void Awake()
    {
       // this.gameObject.SetActive(false);
    }

    public void Enable()
    {
        this.gameObject.SetActive(true);
        var m = GetComponentInParent<UIPlanetManager>().GetCurrentPlanet();
        var p = m.GetComponent<UIInformation>();
        GetComponent<ResourcesButtonsUpdater>().ResetButtons( p.GetReceouceNumber(Receources.SEEDS), p.GetReceouceNumber(Receources.WATER), p.GetReceouceNumber(Receources.MONEY));
    }



    public void Disable()
    {
        this.gameObject.SetActive(false);
    }


}
