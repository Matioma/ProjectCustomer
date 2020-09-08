using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetUIController : MonoBehaviour
{
    Transform targetCamera;

    [SerializeField]
    PlanetStatsUI PlanetUI;



    [SerializeField]
    GameObject RegionUI;


    GameObject OpenedUI;




    private void Awake()
    {
        PlanetUI = transform.GetComponentInChildren<PlanetStatsUI>();
        PlanetUI.gameObject.SetActive(false);



        targetCamera = CameraController.Instance.transform;

        Planet planetManager = transform.parent.GetComponent<Planet>();
        if (planetManager != null)
        {
            transform.parent.GetComponent<Planet>().OnSelected.AddListener(OpenUI);
            transform.parent.GetComponent<Planet>().OnDeselected.AddListener(CloseUI);
        }
        else
        {
            Debug.Log("Parent does not have PlanetManager Component make sure it is present");
        }
        // Subscribing to Zones
        foreach (ZoneSelection zone in transform.parent.GetComponentsInChildren<ZoneSelection>())
        {
            zone.OnSelected.AddListener(openZoneUI);
        }
        foreach (ZoneSelection zone in transform.parent.GetComponentsInChildren<ZoneSelection>())
        {
            //zone.OnDeselected += closeZoneUI;
        }
    }

    private void Start()
    {


       
    }

    void Update()
    {
        if (transform.parent.GetComponent<Planet>().IsSelected)
        {
            transform.LookAt(targetCamera);
        }
    }

    void OpenUI()
    {
        PlanetUI.gameObject.SetActive(true);
    }

    void CloseUI()
    {
        PlanetUI.gameObject.SetActive(false);
    }

    void openZoneUI()
    {
        Debug.Log("Make visible");
    }

}
