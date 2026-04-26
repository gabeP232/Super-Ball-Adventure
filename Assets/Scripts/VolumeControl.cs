using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{

    [SerializeField] private Slider slider;

    private void Awake()
    {
        // attach slider to the volume slider component
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        // get slider volume from the AudioManager
        slider.value = AudioManager.Instance.GetVolume();
        // if value is changed change it in the audio manager, which then also changes it here
        slider.onValueChanged.AddListener(OnSliderChanged);
    }


    // when volume slider is changed, change the presistent savedVolume
    private void OnSliderChanged(float value)
    {
        // set the volume in audio manager if changed
        AudioManager.Instance.SetVolume(value);
    }
}
