using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetManager : SelectableObject
{
    public float MinCameraDistFromPlanet;
    public float GetDistance() {

        return MinCameraDistFromPlanet;
    }
}
