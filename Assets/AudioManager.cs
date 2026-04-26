using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// is attached to the audio obj, so it is active even when the volume control is not visible
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private const string VOLUME_PREF_KEY = "MasterVolume";

    private void Awake()
    {
        Instance = this;
        ApplySavedVolume();
    }

    // apply the new persistent volume 
    public void SetVolume(float value)
    {
        // set volume slider to volume value from audio listener
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(VOLUME_PREF_KEY, value);
        PlayerPrefs.Save();
    }

    // default volume 50%
    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_PREF_KEY, 0.5f);
    }

    // if changed, save the new persistent volume
    private void ApplySavedVolume()
    {
        AudioListener.volume = GetVolume();
    }
}
