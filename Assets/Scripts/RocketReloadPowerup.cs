using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketReloadPowerup : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] AudioClip rocketReloadPowerupSound;
    [SerializeField] [Range(0, 1)] public float soundVolume = 0.7f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
            RocketCountUpdate.instance.RocketReset();
            RocketCountUpdate.instance.UpdateRocketIcons();
            AudioSource.PlayClipAtPoint(rocketReloadPowerupSound, Camera.main.transform.position, soundVolume);
            GameManager.instance.PlaySound();
            Destroy(gameObject);
            }
    }

}
