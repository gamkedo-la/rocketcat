using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    public bool isMuted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            AudioSource newSource = GetComponent<AudioSource>();
            AudioSource oldSource = instance.GetComponent<AudioSource>();
            if (newSource.clip == oldSource.clip)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(instance.gameObject);
                instance = this;
                DontDestroyOnLoad(instance);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMuted = !isMuted;

            AudioListener.pause = isMuted;
        }
    }


    public void IsMuted()
    {
        isMuted = !isMuted;

        AudioListener.pause = isMuted;
    }

}
