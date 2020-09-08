using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipManager : MonoBehaviour
{
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
