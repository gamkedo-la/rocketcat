using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHeart : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] AudioClip alienHeartSound;
    [SerializeField] [Range(0, 1)] public float soundVolume = 0.7f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AlienHeartCountUpdate.instance.UpdateAlienHeartCount();
            AudioSource.PlayClipAtPoint(alienHeartSound, Camera.main.transform.position, soundVolume);
            GameManager.instance.PlaySound();
            Destroy(gameObject);
        }
    }


}
