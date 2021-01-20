using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointMaster cm;

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
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
        }
    }



}
