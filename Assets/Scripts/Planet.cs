﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public float MinCameraDistFromPlanet;

    public float GetDistance() {

        return MinCameraDistFromPlanet;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime);
    }
}
