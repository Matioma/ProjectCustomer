using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = AudioManager.Instance.GetVolume();
       
        slider.onValueChanged.AddListener(onChangedVolume);
      
    }

    void onChangedVolume(float value)
    {
        AudioManager.Instance.SetVolume(value);

    }
    void Update()
    {
        
    }


}
