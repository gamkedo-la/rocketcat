using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{


    [Header("Sound")]
    [SerializeField] AudioClip checkpointSound;
    [SerializeField] [Range(0, 1)] public float soundVolume = 0.7f;
    private bool used = false;

    private void Start()
    {
        gameObject.GetComponentInChildren<Renderer>().enabled = true;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(used)
        {
            return;
        }
        if(other.CompareTag("Player"))
        {
            used = true;
            CheckpointMaster.instance.lastcheckpointpos = transform.position;
            Debug.Log("Checkpoint updated");
            Health.instance.ResetHealth();
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
            CheckpointMaster.instance.currentEnemyCount = EnemyCountUpdate.instance.EnemyCount();
            AudioSource.PlayClipAtPoint(checkpointSound, Camera.main.transform.position, soundVolume);
            GameManager.instance.PlaySound();
        }
    }


}
