using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : SingletonMenobehaviour<AudioManager>
{
    [SerializeField]
    AudioMixer audioMixer;
    //public static AudioManager Instance
    //{
    //    get{
    //        if (_instance != null)
    //        {
    //            return _instance;
    //        }
    //        else {
    //            Debug.LogWarning("Audio manager Does not exist in this scene, creating a new one");
    //            GameObject AudioManager = new GameObject();
    //            AudioManager.AddComponent<AudioManager>();
    //            return _instance;
    //        }
    //    }
    //    set{
    //        if (_instance != null) {
    //            Debug.LogWarning("Tried to create Second Audio manager, the last one is being deleted");
    //            Destroy(value.gameObject);
    //            return;
    //        }
    //        _instance = value;
    //    }
    //}

   

    [SerializeField]
    AudioClip BackgroundMusic;

    [SerializeField] 
    AudioClip ClickingButton;


    [SerializeField]
    AudioClip DefeatSound;



    [SerializeField]
    AudioClip SelectingMaterial;

    [SerializeField]
    AudioClip PeopleStartDying;

    [Header("Select Zone")]
    [SerializeField]
    AudioClip SelectZoneSound;


    [Header("Upgrade sounds!")]
    [SerializeField]
    AudioClip LevelUpgradeSound;
    [SerializeField]
    AudioClip UnableToBuyUpgrade;


    float currentVolume = 0.8f;


    private void Awake()
    {
        Instance = this;

        if (WarningAudio.Instance != null)
        {
            WarningAudio.Instance.SetWarningSound(PeopleStartDying);
        }



        foreach (Button obj in FindObjectsOfType<Button>())
        {
            obj.onClick.AddListener(() =>
            {
            });
            obj.onClick.AddListener(OnButtonClick);
        }
    }

    private void Start()
    {
        warningSounds();

        GlobalTimer.Instance.OnTimerEnd += () =>
        {
            if (DefeatSound != null)
                GetComponent<AudioSource>().PlayOneShot(DefeatSound);
        };

       


        //Subscribe to Zone Selection Sound
        CameraController.Instance.OnSelectZone += () =>
        {
            if(SelectZoneSound!=null)
            GetComponent<AudioSource>().PlayOneShot(SelectZoneSound);
        };


        //Subscribe to ZoneUpgrading Sounds
        foreach (var obj in Resources.FindObjectsOfTypeAll<BuyUpgrade>())
        {
            obj.OnZoneUpgrade += () =>
            {
                if (LevelUpgradeSound != null)
                {
                    GetComponent<AudioSource>().PlayOneShot(LevelUpgradeSound);
                }
            };
            obj.OnTryUpgradeWithoutMoney += () =>
            {
                if (UnableToBuyUpgrade != null)
                {
                    GetComponent<AudioSource>().PlayOneShot(UnableToBuyUpgrade);
                }
            };
        }
    }


    public void OnButtonClick() {
        Debug.LogWarning("CLicking on button");
        if (ClickingButton != null) {
            GetComponent<AudioSource>().PlayOneShot(ClickingButton);
        }
        
    }

    public void warningSounds() {
        foreach (var obj in Resources.FindObjectsOfTypeAll<PlanetReceources>())
        {
            obj.OnPeopleStartLackFood += () =>
            {
                if (PeopleStartDying != null)
                {
                    WarningAudio.Instance.PlayAudioSound();
                }

            };
        }

    }

    private void Update()
    {
        ManualVolumeTesting();
        SetVolume(currentVolume);
    }

    void ManualVolumeTesting() {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentVolume += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentVolume -= 0.1f;
        }
        if (currentVolume > 1)
        {
            currentVolume = 1;
        }
        if (currentVolume <= 0)
        {
            currentVolume = 0;
        }
    }


    public void SetVolume(float volumeFraction) {
        if (audioMixer == null) {
            Debug.Log("Audio Mixer is Not referened in Audio Manager");
        }
        audioMixer.SetFloat("AudioVolume", volumeFraction*100 -80.0f);
    }
}
