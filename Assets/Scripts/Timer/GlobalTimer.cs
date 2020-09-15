using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GlobalTimer : MonoBehaviour
{
    static GlobalTimer _instance; 
    public static GlobalTimer Instance
    {
        get {
            if (_instance == null) {
                Debug.LogWarning("Make sure that your scene has GlobatTimer attached to any object");
            }
            return _instance;  
        }
        set {
            if (_instance != null && _instance != value) {
                Destroy(value.gameObject);
                Debug.LogWarning("Tried to override golbat Timer value, the object is being Destroyed");
            }
        }
    }

    float deltaTime = 0f;
    public float DeltaTime{
        get{ return Time.deltaTime*TimeMultiplier; }
        set{
        }
    }

    public bool TimerIsStarted=false;

    public event Action OnDefeat;

    [SerializeField]
    float GameLengthInSeconds;
    float GameTimeLeftTimer;



    public float TimeMultiplier = 1;


    public void StartTimer() {
        TimerIsStarted= true;
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
        if (GameTimeLeftTimer < 0) {
            OnDefeat?.Invoke();
        }
            
    }

}
