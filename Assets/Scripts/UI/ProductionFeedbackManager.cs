using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProductionFeedbackManager : MonoBehaviour
{
    [SerializeField]
    GameObject FeedBackPrefab;
    //List<ReceourceZone> planetReceourceZones;

    [SerializeField]
    float rangeFromCenter=500;
        
    void Start()
    {
        var planetReceurcesZones = GetComponentInParent<Planet>().GetComponentsInChildren<ReceourceZone>();
        foreach (ReceourceZone receourceZone in planetReceurcesZones) {
            receourceZone.onEndProductionCycle += ()=> {
                //SpawnNumber(receourceZone);
            };
        }
    }
    void SpawnNumber(ReceourceZone receourceZone) {
        var obj = Instantiate(FeedBackPrefab,transform);
        Vector3 continentDirection = receourceZone.GetComponentInChildren<ContinentDirection>().getDirection();

        obj.transform.localPosition = transform.position + continentDirection * rangeFromCenter ;


        var movingNumber = obj.GetComponent<MovingNumber>();
        if (movingNumber != null) { 
            movingNumber.Direction = continentDirection;
        }


        //var movingNumber = obj.GetComponent<MovingNumber>();
        //movingNumber.Direction = receourceZone.GetComponentInChildren<ContinentDirection>().getWorldDirection();

        //obj.transform.localPosition += receourceZone.GetComponentInChildren<ContinentDirection>().getWorldDirection()*1000f;
        //Debug.Log("One Cycle done " + receourceZone.GetProductionAmount() + " " + receourceZone.GetResourceType());
    }

    void Update()
    {
        
    }
}
