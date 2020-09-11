using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionFeedbackManager : MonoBehaviour
{
    //List<ReceourceZone> planetReceourceZones;
    
    void Start()
    {
        var planetReceurcesZones = GetComponentInParent<Planet>().GetComponentsInChildren<ReceourceZone>();
        foreach (ReceourceZone receourceZone in planetReceurcesZones) {
            receourceZone.onEndProductionCycle += ()=> {
                Debug.Log("One Cycle done " + receourceZone.GetProductionAmount() + " " + receourceZone.GetResourceType());
            };
        }
    }

    void DisplayMessage()
    {

        Debug.Log("One Cycle done" );
    }
    void Update()
    {
        
    }
}
