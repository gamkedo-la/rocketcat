using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenSounds : MonoBehaviour
{

    public AudioSource onClickSound;
    public AudioSource mouseSound;
    public AudioClip mouseOverSound;



    public void playSoundEffect()
    {
        onClickSound.Play();
    }

    public void OnMouseOver()
    {
        Debug.Log("mouseOverSound Sound Played");
        mouseSound.PlayOneShot(mouseOverSound, 1f);
    }


}
