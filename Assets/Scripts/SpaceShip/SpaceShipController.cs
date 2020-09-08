using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField]
    Planet targetPlanet;

    [SerializeField]
    float speed;
    public void SetTargetPlanet(Planet ptargetPlanet)
    {
        targetPlanet = ptargetPlanet;
    }
    void Update()
    {
        if (targetPlanet == null) {
            Debug.Log("SpaceShip has no targetPlanet");
            return;
        }

        transform.LookAt(targetPlanet.transform);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
