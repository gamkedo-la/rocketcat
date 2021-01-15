using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketReloadPowerup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
            RocketCountUpdate.instance.RocketReset();
            Destroy(gameObject);
            }
    }



}
