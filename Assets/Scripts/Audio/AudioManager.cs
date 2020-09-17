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
    public float GetVolume() {
        return currentVolume;
    }


    private void Awake()
    {
        Instance = this;

      


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
        if (WarningAudio.Instance != null)
        {
            WarningAudio.Instance.SetWarningSound(PeopleStartDying);
        }

        warningSounds();

        GlobalTimer.Instance.OnDefeat += () =>
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
            Debug.LogWarning("Audio Mixer is Not referened in Audio Manager");
        }
        currentVolume = volumeFraction;
        audioMixer.SetFloat("AudioVolume", volumeFraction*100 -80.0f);
    }
}
