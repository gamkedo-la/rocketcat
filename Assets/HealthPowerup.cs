using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    public bool doesRotate;
    public float rotateSpeed = 100f;
    private int directionNum = -1;

    [Header("Sound")]
    [SerializeField] AudioClip healthPowerupSound;
    [SerializeField] [Range(0, 1)] public float soundVolume = 0.7f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health.instance.ResetHealth();
            AudioSource.PlayClipAtPoint(healthPowerupSound, Camera.main.transform.position, soundVolume);
            GameManager.instance.PlaySound();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doesRotate)
            transform.Rotate(Vector3.down * Time.deltaTime * directionNum * rotateSpeed);
    }
}
