using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    [SerializeField]
    Vector3 rotationVelocity;

    void Update()
    {
        transform.Rotate(rotationVelocity * GlobalTimer.Instance.DeltaTime);
    }
}
