using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDeflect : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    [SerializeField] [Range(0, 1)] float shieldSoundVol = 1f;


    public void DeflectShot(RocketMove rocket)
    {
        Rigidbody2D rb = rocket.GetRB();
        //rb.velocity = -rb.velocity;
        rocket.transform.Rotate(Vector3.forward, Random.Range(-10f, 10f) + 180.0f);
        Debug.Log("Attempted to deflect");
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            audioSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            audioSource.PlayOneShot(audioSource.clip, shieldSoundVol);
        }
        else
        {
            return;
        }
    }

}
