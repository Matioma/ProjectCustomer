using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

using UnityEngine;
using UnityEngine.Events;

public class GlobalTimer : SingletonMenobehaviour<GlobalTimer>
{
    public int foodRequiredCondition;

    float deltaTime = 0f;
    public float DeltaTime{
        get{
            if (GameIsPaused) {
                return 0.0f;
            }
            return Time.deltaTime*TimeMultiplier; }
        set{
        }
    }
    public float NonAcceleratedTime {
        get {
            if (GameIsPaused) {
                return 0.0f;
            }
            return Time.deltaTime; 
        }
    }

    public bool TimerIsStarted { get; private set; } = false;
    public bool GameIsPaused { 
        get; private set; } = false;

    public void SetGameIsPaused(bool value)
    {
        if (value == GameIsPaused) {
            return;
        }

        if (value)
        {
            OnPauseGame?.Invoke();
        }
        else {
            OnContinueGame?.Invoke();
        }
        GameIsPaused = value;
    }


    [SerializeField]
    UnityEvent OnPauseGame;
    [SerializeField]
    UnityEvent OnContinueGame;





    public bool GameEnded = false;

    public event Action OnTimerEnd;

    public event Action OnVictory;
    public event Action OnDefeat;

    [SerializeField]
    float GameLengthInSeconds;
    float GameTimeLeftTimer;




    public float GetTimeLeft() {
        return GameTimeLeftTimer;
    }

    [SerializeField]
    int[] acelerationValues;
    int accelerationValueIndex = 0;



    float multiplierBeforePause;
    [SerializeField]
    float TimeMultiplier = 1;
    public float GetTimeMultiplier() {
        return TimeMultiplier;
    }

    public void StopGame() {
        SetGameIsPaused(true);
        //GameIsPaused = true;
        //Debug.LogWarning("Game Paused"); ;
    }

    public void ResumeGame() {
        SetGameIsPaused(false);
        //GameIsPaused = false;
    }
    public void AccelerateGame()
    {
        accelerationValueIndex  = (accelerationValueIndex +1)% acelerationValues.Length;
        TimeMultiplier = acelerationValues[accelerationValueIndex];
    }
    public void StartTimer() {
        TimerIsStarted= true;
    }

    private void Awake()
    {
        base.Awake();
        OnDefeat += UpdateDefeatStats;
        //Instance = this;
        multiplierBeforePause = TimeMultiplier;
        GameTimeEnded();
    }

    void Start()
    {
        GameTimeLeftTimer = GameLengthInSeconds;        
    }

    void Update()
    {
        if (!TimerIsStarted) {
            return;
        }
        GameTimeLeftTimer -= DeltaTime;
        if (GameTimeLeftTimer < 0) {
            if (!GameEnded) { 
                OnTimerEnd?.Invoke();
                GameEnded = true;
            }
        }
    }

    public void UpdateDefeatStats() {
        var defeatStats = Resources.FindObjectsOfTypeAll<DefeatStats>();
        if (defeatStats.Length == 0) {
            Debug.LogError("THe scene is missing DefeastStats object");
            return;
        }

        //Debug.Log(defeatStats[0].transform.name);

        var Planets = FindObjectsOfType<Planet>();
      
        foreach (var planet in Planets)
        {
            //Debug.Log(planet.transform.name);
            PlanetReceources planetReceources = planet.GetComponentInChildren<PlanetReceources>();
            //Debug.Log(planetReceources.getPopulation() + "SHould add A planet stats");
            //if (planetReceources.getPopulation() < foodRequiredCondition)
            //{
                
            defeatStats[0].AddLostPlanet(planet.GetComponent<UIInformation>());
            //}
        }
    }




    void GameTimeEnded()
    {
        OnTimerEnd += () =>
        {
            if (HasWon())
            {
                OnVictory?.Invoke();
                GetComponent<CanvasSwitcher>()?.OpenScreen(CanvasType.WinScreen);
            }
            else
            {
               
                OnDefeat?.Invoke();
                GetComponent<CanvasSwitcher>()?.OpenScreen(CanvasType.LoseScreen);

            }
            StopGame();
        };
    }

    bool HasWon()
    {
        foreach(var planetResource in Resources.FindObjectsOfTypeAll<PlanetReceources>())
        {
            if (planetResource.getPopulation() < foodRequiredCondition) {
                return false;
            }
        }
        return true;
    }

}
