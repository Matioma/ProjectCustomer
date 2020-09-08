using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Planet : SelectableObject
{
    public float MinCameraDistFromPlanet;
    public float GetDistance() {

        return MinCameraDistFromPlanet;
    }
}
