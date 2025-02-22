﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class GeneralZoneUpdater : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI population;
    [SerializeField]
    TextMeshProUGUI hungryPeople;
    [SerializeField]
    TextMeshProUGUI deathRate;
    [SerializeField]
    TextMeshProUGUI birthRate;
    [SerializeField]
    TextMeshProUGUI consumptionRateSeed;

    public void Initialize(int populationNumber, int hungryPeopleNumber, int deathRateNumber, int deathRateTime, int birthRateNumber, int birthRateTime, int consumptionSeedNumber, int consumptionSeedTime)
    {
        UpdatePopulationNumber(populationNumber);
        UpdateHungryPeople(hungryPeopleNumber);
        UpdateDeathRate(deathRateNumber, deathRateTime);
        UpdateBirthRate(birthRateNumber, birthRateTime);
        UpdateSeedConsumptionRate(consumptionSeedNumber, consumptionSeedTime);
    }

    public void UpdatePopulationNumber(int newNumber)
    {
        population.text = newNumber.ToString();
    }
    public void UpdateHungryPeople(int newNumber)
    {
        hungryPeople.text = "Hungry people: " + newNumber.ToString();
    }
    public void UpdateDeathRate(int newRateNumber, int newRateTime)
    {
        deathRate.text = "Death Rate: " + newRateNumber.ToString() + " / " + newRateTime.ToString() + " s";
    }
    public void UpdateBirthRate(int newRateNumber, int newRateTime)
    {
        birthRate.text = "Birth Rate: " + newRateNumber.ToString() + " /s ";// + newRateTime.ToString() + " s";
    }

    public void UpdateSeedConsumptionRate(int consumptionSeedNumber, int consumptionSeedTime)
    {
        consumptionRateSeed.text = "Population is consuming:         " + consumptionSeedNumber.ToString() + " /s ";// + consumptionSeedTime.ToString() + " s";
    }


}
