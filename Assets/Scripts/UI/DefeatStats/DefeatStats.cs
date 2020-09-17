using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefeatStats : MonoBehaviour
{
    [SerializeField]
    GameObject planetStatsPrefab;

    void Start()
    {
    }

    void Update()
    {

    }


    public void AddLostPlanet(UIInformation uIInformation) {
        var obj = Instantiate(planetStatsPrefab, GetComponent<RectTransform>());

        DefeatPlanetName defeatPlanetName = obj.GetComponentInChildren<DefeatPlanetName>();
        defeatPlanetName.GetComponent<TextMeshProUGUI>().text += uIInformation.GetPlanetName();

        DefeatPopulationNumber defeatPopulationNumber = obj.GetComponentInChildren<DefeatPopulationNumber>();
        defeatPopulationNumber.GetComponent<TextMeshProUGUI>().text += uIInformation.GetPopulation().ToString();

        DefeatHungryPeople defeatHungryPeople = obj.GetComponentInChildren<DefeatHungryPeople>();
        defeatHungryPeople.GetComponent<TextMeshProUGUI>().text += uIInformation.GetHungryPeople().ToString();
    }
}
