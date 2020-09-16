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
        transform.position += transform.forward * speed * GlobalTimer.Instance.DeltaTime;
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetPlanet.gameObject) {
            UnloadTheShip(other.gameObject.GetComponentInChildren<PlanetReceources>());
        }
    }
    void UnloadTheShip(PlanetReceources targetPlanet)
    {
        UnitResources thisShipResources = GetComponent<UnitResources>();
        if (targetPlanet != null)
        {
            foreach (var resource in thisShipResources.GetResources())
            {
                targetPlanet.AddReceource(resource.Key, resource.Value);
            }
        }
        else {
            Debug.Log("The target planet has no PlanetResources component");
        }
        Destroy(this.gameObject);
    }


}
