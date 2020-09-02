using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetUIController : MonoBehaviour
{
    [SerializeField]
    Transform targetCamera;

    private void Start()
    {
        targetCamera = CameraRotation.Instance.transform;

        transform.parent.GetComponent<PlanetManager>().OnPlanetSelected += OpenUI;
    }

    void Update()
    {
        transform.LookAt(targetCamera);
    }



    void OpenUI() {

    }



}
