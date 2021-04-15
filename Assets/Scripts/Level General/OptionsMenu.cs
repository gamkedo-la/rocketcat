using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public bool isPauseMuted = false;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void IsMuted()
    {
        isPauseMuted = !isPauseMuted;

        AudioListener.pause = isPauseMuted;
    }
}
