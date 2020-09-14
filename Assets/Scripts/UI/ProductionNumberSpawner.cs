using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ProductionNumberSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject FeedBackPrefab;
    //List<ReceourceZone> planetReceourceZones;

    [SerializeField]
    float rangeFromCenter=250;

    Planet owningPlanet;

    [SerializeField]
    List<IndicatorPairs> ResourceImagePairs;
        
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
        //Debug.DrawRay(transform.position, owningPlanet.transform.rotation* continentDirection * 10000.0f, Color.green, 10.0f);
        

        var indicatorObject = Instantiate(FeedBackPrefab, transform);
        var idicatorRotation = owningPlanet.transform.rotation * continentDirection; // world Rotation of the Indicator
        
        
        indicatorObject.transform.position = transform.position + idicatorRotation.normalized * rangeFromCenter ; // set position
        //Look at relative vector        
        Vector3 relativeVector = indicatorObject.transform.position - transform.position;
        indicatorObject.transform.rotation = Quaternion.LookRotation(relativeVector, Vector3.up);


        var TextMessege = indicatorObject.GetComponent<MovingNumber>();
        if (TextMessege != null) {
            TextMessege.GetComponentInChildren<TextMeshProUGUI>().text = receourceZone.GetProductionAmount() + " " + receourceZone.GetResourceType();
            indicatorObject.GetComponentInChildren<Image>().sprite = GetImageOfType(receourceZone.GetResourceType());
        }
    }

    public Sprite GetImageOfType(Receources receources) {
        foreach (IndicatorPairs pair in ResourceImagePairs) {
            if (pair.resourceType == receources) {
                return pair.image;
            }
        }
        return null;
    }

    void Update()
    {
        
    }
}


[System.Serializable]
class IndicatorPairs {

    public Receources resourceType;
    public Sprite image;

}
