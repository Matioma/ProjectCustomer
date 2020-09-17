using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourceButtonsSwitcher : MonoBehaviour
{
    [SerializeField]
    GameObject planet;

    public void Enable()
    {
        this.gameObject.SetActive(true);
        var p = planet.GetComponent<UIInformation>();
        GetComponent<ResourcesButtonsUpdater>().ResetButtons( p.GetReceouceNumber(Receources.SEEDS), p.GetReceouceNumber(Receources.WATER), p.GetReceouceNumber(Receources.MONEY));
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }


}
