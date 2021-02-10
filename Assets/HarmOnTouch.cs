using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmOnTouch : MonoBehaviour
{
    Health toHarm;
    float timeTilNextHarm = 0.0f;
    float hurtFreq = 0.25f;

    private void Update()
    {
        if(toHarm)
        {
            timeTilNextHarm -= Time.deltaTime;
            if(timeTilNextHarm <= 0.0f)
            {
                toHarm.DealDamage();
                timeTilNextHarm = hurtFreq;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            toHarm = other.collider.GetComponent<Health>();
            toHarm.DealDamage();
            timeTilNextHarm = hurtFreq;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            toHarm = null;
        }
    }

}
