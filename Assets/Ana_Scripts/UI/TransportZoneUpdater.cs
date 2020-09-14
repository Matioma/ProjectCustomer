﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportZoneUpdater : MonoBehaviour
{
    [SerializeField]
    Button ChangeToSeeds;
    [SerializeField]
    Button ChangeToWater;
    [SerializeField]
    Button ChangeToMoney;

    [SerializeField]
    Slider slider;

    [SerializeField]
    Button ChangeToPlanetA;
    [SerializeField]
    Button ChangeToPlanetB;

    [SerializeField]
    Button Send;

    [System.Serializable]
    public class PlanetIcon
    {
        public GameObject planet;
        public Image planetIcon;
    }
    [SerializeField]
    List<PlanetIcon> planets;
    List<PlanetIcon> modifiedPlanets;
    GameObject Invest;

    public void Initialize(GameObject IndustrialZone, GameObject currentPlanet)
    {
        Invest = IndustrialZone;
        ChangePlanetList(currentPlanet);
        ChangeButtonsResourceChange();
        ChangeValueInSlider();
        ChangePlanetDestination();
        UpdateSendButton();
    }

    void ChangeButtonsResourceChange()
    {
        ChangeToSeeds.onClick.RemoveAllListeners();
        ChangeToWater.onClick.RemoveAllListeners();
        ChangeToMoney.onClick.RemoveAllListeners();

        ChangeToSeeds.onClick.AddListener(OnResourceChangeToSeeds);
        ChangeToWater.onClick.AddListener(OnResourceChangeToWater);
        ChangeToMoney.onClick.AddListener(OnResourceChangeToMoney);
    }

    private void OnResourceChangeToSeeds()
    {
        Invest.GetComponent<SendReceources>().ChangeTypeOfReceource(Receources.SEEDS);
    }
    private void OnResourceChangeToWater()
    {
        Invest.GetComponent<SendReceources>().ChangeTypeOfReceource(Receources.WATER);
    }
    private void OnResourceChangeToMoney()
    {
        Invest.GetComponent<SendReceources>().ChangeTypeOfReceource(Receources.MONEY);
    }

    private void ChangeValueInSlider()
    {
        slider.onValueChanged.RemoveAllListeners();
        slider.onValueChanged.AddListener(OnCurrentAmountChange);
    }

    private void OnCurrentAmountChange(float value)
    {
        Invest.GetComponent<SendReceources>().ChangeAmount(value);
    }
    private void ChangePlanetList(GameObject currentPlanet)
    {
        modifiedPlanets.Clear();
        for (int i = 0; i < planets.Count; i++)
        {
            if (planets[i].planet != currentPlanet)
            {
                modifiedPlanets[i] = planets[i];
            }
        }
    }

    void ChangePlanetDestination()
    {
        ChangeToPlanetA.onClick.RemoveAllListeners();
        ChangeToPlanetB.onClick.RemoveAllListeners();

        var imageToChangeA = ChangeToPlanetA.GetComponentInChildren<Image>();
        imageToChangeA = modifiedPlanets[0].planetIcon;
        var imageToChangeB = ChangeToPlanetB.GetComponentInChildren<Image>();
        imageToChangeB = modifiedPlanets[1].planetIcon;

        ChangeToPlanetA.onClick.AddListener(OnPlanetChangeToA);
        ChangeToPlanetB.onClick.AddListener(OnPlanetChangeToB);
    }

    private void OnPlanetChangeToA()
    {
        Invest.GetComponent<SendReceources>().ChangeDestination(modifiedPlanets[0].planet);
    }
    private void OnPlanetChangeToB()
    {
        Invest.GetComponent<SendReceources>().ChangeDestination(modifiedPlanets[1].planet);

    }

    void UpdateSendButton()
    {
        Send.onClick.RemoveAllListeners();
        Send.onClick.AddListener(OnSendButtonPress);
    }
    private void OnSendButtonPress()
    {
        Invest.GetComponent<SendReceources>().Send();
    }


}
