using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    private const string VOLUME_PREF_KEY = "MasterVolume";

    [SerializeField] private Slider slider;

    private void Awake()
    {
        // default at 0.25 volume
        float savedVolume = PlayerPrefs.GetFloat(VOLUME_PREF_KEY, 0.25f);
        slider.value = savedVolume;
        AudioListener.volume = savedVolume;

        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    // when volume slider is changed, change the presistent savedVolume
    private void OnSliderChanged(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(VOLUME_PREF_KEY, value);
        PlayerPrefs.Save();
    }
}
