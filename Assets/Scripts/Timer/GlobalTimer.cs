using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

using UnityEngine;

public class GlobalTimer : SingletonMenobehaviour<GlobalTimer>
{
    //static GlobalTimer _instance;
    //public static GlobalTimer Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            Debug.LogWarning("Make sure that your scene has GlobatTimer attached to any object");
    //        }
    //        return _instance;
    //    }
    //    set
    //    {
    //        if (_instance != null && _instance != value)
    //        {
    //            Destroy(value.gameObject);
    //            Debug.LogWarning("Tried to override golbat Timer value, the object is being Destroyed");
    //            return;
    //        }
    //        _instance = value;
    //    }
    //}

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


    public bool TimerIsStarted { get; private set; } = true;
    public bool GameIsPaused { get; private set; } = false;


    public event Action OnTimerEnd;

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
        //TimeMultiplier *= 2;
    }

    public void StartTimer() {
        TimerIsStarted= true;
    }

    private void Awake()
    {
        Instance = this;
        multiplierBeforePause = TimeMultiplier;
        OpenWinScreen();

    }

    void OpenWinScreen() {
        OnTimerEnd += () =>
        {
            GetComponent<CanvasSwitcher>()?.OnScreenChange();
            StopGame();
        };
    }


    void Start()
    {
        GameTimeLeftTimer = GameLengthInSeconds;        
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimerIsStarted) {
            return;
        }

        GameTimeLeftTimer -= DeltaTime;

        //Debug.Log(DeltaTime);
        if (GameTimeLeftTimer < 0) {
            OnTimerEnd?.Invoke();
        }
            
    }

}
