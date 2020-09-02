using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetState : MonoBehaviour
{
    [SerializeField]
    int foodState = 300;
    [SerializeField]
    int CurrentPlanetMoney = 300;
    int decrease = -1;
    int currentMaxFoodState;

    public int Money
    {
        get
        {
            return CurrentPlanetMoney;
        }
        set
        {
            CurrentPlanetMoney = value;
        }
    }

    private void Awake()
    {
        currentMaxFoodState = foodState;
    }

    public int Decrease
    {
        set
        {
            decrease += value;
            currentMaxFoodState += value * 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foodState += decrease;
    }
}
