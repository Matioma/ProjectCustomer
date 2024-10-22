﻿using UnityEngine;

public class PlanetIndicator : MonoBehaviour
{
    CameraController player;

    [SerializeField]
    GameObject exclamationMark;
    [SerializeField]
    GameObject timerObject;



    private void Awake()
    {
        //timerObject = GetComponentInChildren<WarningTimer>().gameObject;
        //exclamationMark = GetComponentInChildren<ExclamationMark>().gameObject;
    }


    void Start()
    {
        HideUI();
        HideTimer();
        HideExclamationMark();

        player = CameraController.Instance;
        if (player != null) {
            player.OnZoomToWorldView += ShowUI;
            player.OnZoomToPlanet+= HideUI;
        }

        PlanetReceources planet= transform.GetComponentInParent<Planet>().GetComponentInChildren<PlanetReceources>();
        if (planet != null) {
            planet.OnPeopleStartLackFood += ShowTimer;
            planet.OnPeopleStartDying += ShowExplamationMark;


            planet.OnPeopleStopLackFood += HideTimer;
            planet.OnPeopleStopLackFood += HideExclamationMark;
        }
    }
    void Update()
    {
    }

    void ShowTimer() {
        timerObject.SetActive(true);
        IsIndicatorVisible isIndicatorVisible = timerObject.GetComponent<IsIndicatorVisible>();
        isIndicatorVisible.Visible = true;
    }
    void HideTimer()
    {
        timerObject.SetActive(false);
        IsIndicatorVisible isIndicatorVisible = timerObject.GetComponent<IsIndicatorVisible>();
        isIndicatorVisible.Visible = false;
    }
    void ShowExplamationMark()
    {
        Debug.Log("Planet Is Dying");
        exclamationMark.SetActive(true);
        IsIndicatorVisible isIndicatorVisible = exclamationMark.GetComponent<IsIndicatorVisible>();
        isIndicatorVisible.Visible = true;
    }
    void HideExclamationMark() {
        exclamationMark.SetActive(false);
        IsIndicatorVisible isIndicatorVisible = exclamationMark.GetComponent<IsIndicatorVisible>();
        isIndicatorVisible.Visible = false;
    }


    void ShowUI() {
        gameObject.SetActive(true);
    }

    void HideUI() {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (player != null)
        {
            player.OnZoomToWorldView -= ShowUI;
            player.OnZoomToPlanet -= HideUI;
        }
    }
}
