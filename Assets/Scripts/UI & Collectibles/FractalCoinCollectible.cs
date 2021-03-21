using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalCoinCollectible : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] AudioClip fractalCollectibleSound;
    [SerializeField] [Range(0, 1)] public float soundVolume = 0.7f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FractalCoinCountUpdate.instance.UpdateCoinFractalCount();
            AudioSource.PlayClipAtPoint(fractalCollectibleSound, Camera.main.transform.position, soundVolume);
            GameManager.instance.PlaySound();
            Destroy(gameObject);
        }
    }
}
