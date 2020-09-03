using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetUIController : MonoBehaviour
{
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
            transform.parent.GetComponent<PlanetManager>().OnSelected += OpenUI;
            transform.parent.GetComponent<PlanetManager>().OnDeselected += CloseUI;
        }
        else
        {
            Debug.Log("Parent does not have PlanetManager Component make sure it is present");
        }
        // Subscribing to Zones
        foreach (ZoneSelection zone in transform.parent.GetComponentsInChildren<ZoneSelection>())
        {
            zone.OnSelected += openZoneUI;
        }
        foreach (ZoneSelection zone in transform.parent.GetComponentsInChildren<ZoneSelection>())
        {
            zone.OnDeselected += closeZoneUI;
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
        planetStats.gameObject.SetActive(true);
    }

    void CloseUI()
    {
        planetStats.gameObject.SetActive(false);
    }

    void openZoneUI()
    {
        RegionUI selectedRegion = GetComponentInChildren<RegionUI>();

        CameraRotation camera = CameraRotation.Instance;

        if (camera.SelectedZone != null)
        {
            selectedRegion.regionName.text = camera.SelectedZone.name;
        }
        else
        {
            selectedRegion.regionName.text = "";
        }
    }

    void closeZoneUI()
    {
        RegionUI selectedRegion = GetComponentInChildren<RegionUI>();

        CameraRotation camera = CameraRotation.Instance;

        if (camera.SelectedZone != null)
        {
            selectedRegion.regionName.text = "";
        }
    }

}
