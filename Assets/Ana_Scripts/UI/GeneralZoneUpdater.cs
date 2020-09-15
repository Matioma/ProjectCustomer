using System.Collections;
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


    //public void UpdateGeneralZoneText(Text newText)
    //{
    //    text = newText;
    //}

    //public void UpdateGeneralZoneQuest(Quest newQuest)
    //{
    //    currentQuest = newQuest;
    //}

    public void Initialize(int populationNumber, int hungryPeopleNumber, int deathRateNumber, int deathRateTime, int birthRateNumber, int birthRateTime)
    {
        UpdatePopulationNumber(populationNumber);
        UpdateHungryPeople(hungryPeopleNumber);
        UpdateDeathRate(deathRateNumber, deathRateTime);
        UpdateBirthRate(birthRateNumber, birthRateTime);
    }
    public void UpdateQuestes()
    {

    }
    public void UpdatePopulationNumber(int newNumber)
    {
        population.text = newNumber.ToString();
       // Debug.Log(population.text);
    }
    public void UpdateHungryPeople(int newNumber)
    {
        hungryPeople.text = "Hungry people: " + newNumber.ToString();
    }
    public void UpdateDeathRate(int newRateNumber, int newRateTime)
    {
        deathRate.text = "Death Rate:" + newRateNumber.ToString() + "/" + newRateTime.ToString();
    }
    public void UpdateBirthRate(int newRateNumber, int newRateTime)
    {
        birthRate.text = "Birth Rate: " + newRateNumber.ToString() + "/" + newRateTime.ToString();
    }


}
