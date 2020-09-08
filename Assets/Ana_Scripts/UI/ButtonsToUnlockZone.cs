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
        UIToUnlock.SetActive(true);
        buyButton.gameObject.SetActive(false);
       
    }
}
