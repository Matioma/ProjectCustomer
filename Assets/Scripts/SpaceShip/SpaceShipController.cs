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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetPlanet.gameObject) {
            UnloadTheShip();
        }
    }
    void UnloadTheShip()
    {
        Debug.Log("Unload the ship, reached the destination");
        Destroy(this.gameObject);
    }


}
