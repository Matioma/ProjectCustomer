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
    float rangeFromCenter=250;

    Planet owningPlanet;
        
    void Start()
    {
        owningPlanet = GetComponentInParent<Planet>();

        var planetReceurcesZones = owningPlanet.GetComponentsInChildren<ReceourceZone>();
        foreach (ReceourceZone receourceZone in planetReceurcesZones) {
            receourceZone.onEndProductionCycle += ()=> {
                SpawnNumber(receourceZone);
            };
        }
    }
    void SpawnNumber(ReceourceZone receourceZone) {

        Vector3 continentDirection = receourceZone.GetComponentInChildren<ContinentDirection>().getDirection();
        Debug.DrawRay(transform.position, owningPlanet.transform.rotation* continentDirection * 10000.0f, Color.green, 10.0f);
        

        var indicatorObject = Instantiate(FeedBackPrefab, transform);
        var idicatorRotation = owningPlanet.transform.rotation * continentDirection; // world Rotation of the Indicator
        
        //indicatorObject.transform.rotation = Quaternion.LookRotation(continentDirection, Vector3.up);
        
        indicatorObject.transform.position = transform.position + idicatorRotation.normalized * rangeFromCenter ; // set position
        //indicatorObject.transform.rotation = Quaternion.LookRotation(continentDirection * 10000.0f,Vector3.up);

        //MyTransform targetTransform = new MyTransform();
        Vector3 targetPosition = indicatorObject.transform.position - transform.position;


        indicatorObject.transform.rotation = Quaternion.LookRotation(targetPosition, Vector3.up);


        Debug.Log("One Cycle done " + receourceZone.GetProductionAmount() + " " + receourceZone.GetResourceType());
    }

    void Update()
    {
        
    }
}
