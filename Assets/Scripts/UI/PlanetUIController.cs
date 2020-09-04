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
    }

    private void Start()
    {
        targetCamera = CameraRotation.Instance.transform;

        PlanetManager planetManager = transform.parent.GetComponent<PlanetManager>();
        if (planetManager != null)
        {
            transform.parent.GetComponent<PlanetManager>().OnSelected.AddListener(OpenUI);
            transform.parent.GetComponent<PlanetManager>().OnDeselected.AddListener(CloseUI);
            //transform.parent.GetComponent<PlanetManager>().OnDeselected += CloseUI;
        }
        else
        {
            Debug.Log("Parent does not have PlanetManager Component make sure it is present");
        }
        // Subscribing to Zones
        foreach (ZoneSelection zone in transform.parent.GetComponentsInChildren<ZoneSelection>())
        {
            zone.OnSelected.AddListener(openZoneUI);
            //zone.OnSelected += openZoneUI;
        }
        foreach (ZoneSelection zone in transform.parent.GetComponentsInChildren<ZoneSelection>())
        {
            //zone.OnDeselected += closeZoneUI;
        }
    }

    void Update()
    {
        if (transform.parent.GetComponent<PlanetManager>().IsSelected)
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
