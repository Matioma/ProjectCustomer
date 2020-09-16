using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningAudio  : SingletonMenobehaviour<WarningAudio>
{
    AudioClip WarningSound;
    public void SetWarningSound(AudioClip sound) {
        WarningSound = sound;
    }

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log(Instance);
    }

    public void PlayAudioSound() {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }

        audioSource.PlayOneShot(WarningSound);
    
    }
}
