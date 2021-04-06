using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

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



}
