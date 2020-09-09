using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpaceShipManager : MonoBehaviour
{
    SpaceShipManager _instance;

    public SpaceShipManager Instance
    {
        get {
            if (_instance == null) {
                Debug.Log("There is No SpaceShipManager in the level");
            }
            return _instance; 
        }
        set{
            if (_instance == null)
            {
                _instance = value;
            }
            else
            {
                Debug.Log("Tryingto create second SpaceShipManager, destorying it");
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    GameObject SpaceShipPrefab;


    [SerializeField]
    Planet sendingPlanet;

    [SerializeField]
    Planet targetPlanet;

    public void SendShip(Planet from, Planet to) {
        GameObject spaceShipRef =Instantiate(SpaceShipPrefab, from.transform.position, Quaternion.identity);
        spaceShipRef.GetComponent<SpaceShipController>()?.SetTargetPlanet(to);
    }
    void Start()
    {
        if (sendingPlanet != null && targetPlanet != null) {
            SendShip(sendingPlanet, targetPlanet);
        }
    }
}
