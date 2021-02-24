using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cm;

    [Header("Sound")]
    [SerializeField] AudioClip checkpointSound;
    [SerializeField] [Range(0, 1)] public float soundVolume = 0.7f;

    private void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
        gameObject.GetComponentInChildren<Renderer>().enabled = true;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            cm.lastcheckpointpos = transform.position;
            Debug.Log("Checkpoint updated");
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
            cm.currentEnemyCount = EnemyCountUpdate.instance.EnemyCount();
            AudioSource.PlayClipAtPoint(checkpointSound, Camera.main.transform.position, soundVolume);
            GameManager.instance.PlaySound();
        }
    }


}
