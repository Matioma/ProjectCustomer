using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetUIController : MonoBehaviour
{
    [SerializeField]
    Transform targetCamera;


    PlanetStatsUI planetStats;

    private void Awake()
    {
        planetStats = transform.GetComponentInChildren<PlanetStatsUI>();
        planetStats.gameObject.SetActive(false);
    }


    private void Start()
    {
        targetCamera = CameraRotation.Instance.transform;

        PlanetManager planetManager = transform.parent.GetComponent<PlanetManager>();


        if (planetManager != null)
        {
            transform.parent.GetComponent<PlanetManager>().OnPlanetSelected += OpenUI;
            transform.parent.GetComponent<PlanetManager>().OnPlanetDeselected += CloseUI;
        }
        else {
            Debug.Log("Parent does not have PlanetManager Component make sure it is present");
        }
    }

    void Update()
    {
        transform.LookAt(targetCamera);
    }

    void OpenUI() {
        planetStats.gameObject.SetActive(true);
    }

    void CloseUI() {
        planetStats.gameObject.SetActive(false);
    }

}
