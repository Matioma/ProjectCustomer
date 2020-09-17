using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

using UnityEngine;

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
    public bool GameIsPaused { get; private set; } = false;


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
        GameIsPaused = true;
        Debug.LogWarning("Game Paused"); ;
    }

    public void ResumeGame() {
        GameIsPaused = false;
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
