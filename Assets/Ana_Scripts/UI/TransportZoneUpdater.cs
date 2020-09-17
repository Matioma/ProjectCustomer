using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportZoneUpdater : MonoBehaviour
{
    [SerializeField]
    Button ChangeToSeeds;
    [SerializeField]
    GameObject SeedBackgroundIcon;
    [SerializeField]
    Button ChangeToWater;
    [SerializeField]
    GameObject WaterBackgroundIcon;
    [SerializeField]
    Button ChangeToMoney;
    [SerializeField]
    GameObject MoneyBackgroundIcon;

    [SerializeField]
    Slider slider;

    [SerializeField]
    Button ChangeToPlanetA;
    [SerializeField]
    GameObject PlanetABackgroundIcon;
    [SerializeField]
    Button ChangeToPlanetB;
    [SerializeField]
    GameObject PlanetBBackgroundIcon;

    [SerializeField]
    Button Send;

    [System.Serializable]
    public class PlanetIcon
    {
        public GameObject planet;
        public Sprite planetIcon;
    }
    [SerializeField]
    List<PlanetIcon> planets;
    List<PlanetIcon> modifiedPlanets;
    GameObject Invest;

    private void Awake()
    {
        modifiedPlanets = new List<PlanetIcon>();
    }
    public void Initialize(GameObject IndustrialZone, GameObject currentPlanet,int newSeedNumber, int newWaterNumber, int newMoneyNimber)
    {
        Invest = IndustrialZone;
        //Debug.Log(modifiedPlanets.Count);

        ChangePlanetList(currentPlanet);
        //Debug.Log(modifiedPlanets.Count);

        ChangeButtonsResourceChange();
        ChangeValueInSlider();
        ChangePlanetDestination();
        UpdateSendButton();
        ResetButtons();
        slider.GetComponent<ChangeMaxValue>().ResetButtons(newSeedNumber,newWaterNumber,newMoneyNimber);

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
        slider.GetComponent<ChangeMaxValue>().ChangeRec(Receources.SEEDS);
        SeedBackgroundIcon.SetActive(true);
        WaterBackgroundIcon.SetActive(false);
        MoneyBackgroundIcon.SetActive(false);
    }
    private void OnResourceChangeToWater()
    {
        Invest.GetComponent<SendReceources>().ChangeTypeOfReceource(Receources.WATER);
        slider.GetComponent<ChangeMaxValue>().ChangeRec(Receources.WATER);
        SeedBackgroundIcon.SetActive(false);
        WaterBackgroundIcon.SetActive(true);
        MoneyBackgroundIcon.SetActive(false);
    }
    private void OnResourceChangeToMoney()
    {
        Invest.GetComponent<SendReceources>().ChangeTypeOfReceource(Receources.MONEY);
        slider.GetComponent<ChangeMaxValue>().ChangeRec(Receources.MONEY);
        SeedBackgroundIcon.SetActive(false);
        WaterBackgroundIcon.SetActive(false);
        MoneyBackgroundIcon.SetActive(true);
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
        //if (modifiedPlanets.Count != 0)
        //{
            modifiedPlanets.Clear();
        //}
        //if (planets.Count != 0)
        //{
            for (int i = 0; i < planets.Count; i++)
            {
                if (planets[i].planet != currentPlanet)
                {
                    modifiedPlanets.Add(planets[i]);
                }
            }
        //}
    }

    void ChangePlanetDestination()
    {
        ChangeToPlanetA.onClick.RemoveAllListeners();
        ChangeToPlanetB.onClick.RemoveAllListeners();
        if (modifiedPlanets.Count - 1 >= 0)
        {
            
            var imageToChangeA = ChangeToPlanetA.GetComponent<Image>();
            imageToChangeA.sprite = modifiedPlanets[0].planetIcon;
            ChangeToPlanetA.onClick.AddListener(OnPlanetChangeToA);
           // Debug.Log("Change Icon planetA "+ modifiedPlanets[0].planetIcon.name);
           // Debug.Log("Change Icon planetA "+ modifiedPlanets[0].planet.gameObject.name);
        }
        if (modifiedPlanets.Count - 1 >= 1)
        {
            
            var imageToChangeB = ChangeToPlanetB.GetComponent<Image>();
            imageToChangeB.sprite = modifiedPlanets[1].planetIcon;
            ChangeToPlanetB.onClick.AddListener(OnPlanetChangeToB);
           // Debug.Log("Change Icon planetA " + modifiedPlanets[1].planetIcon.name);
           // Debug.Log("Change Icon planetB "+ modifiedPlanets[1].planet.gameObject.name);
        }
    }

    private void OnPlanetChangeToA()
    {
        Invest.GetComponent<SendReceources>().ChangeDestination(modifiedPlanets[0].planet);
        PlanetABackgroundIcon.SetActive(true);
        PlanetBBackgroundIcon.SetActive(false);
    }
    private void OnPlanetChangeToB()
    {
        Invest.GetComponent<SendReceources>().ChangeDestination(modifiedPlanets[1].planet);
        PlanetABackgroundIcon.SetActive(false);
        PlanetBBackgroundIcon.SetActive(true);
    }

    void UpdateSendButton()
    {
        Send.onClick.RemoveAllListeners();
        Send.onClick.AddListener(OnSendButtonPress);
    }
    private void OnSendButtonPress()
    {
        Invest.GetComponent<SendReceources>().Send();
        ResetButtons();
    }

    private void ResetButtons()
    {
        
        Invest.GetComponent<SendReceources>().ChangeTypeOfReceource(Receources.ALL);
        SeedBackgroundIcon.SetActive(false);
        WaterBackgroundIcon.SetActive(false);
        MoneyBackgroundIcon.SetActive(false);
        PlanetABackgroundIcon.SetActive(false);
        PlanetBBackgroundIcon.SetActive(false);
    }


}
