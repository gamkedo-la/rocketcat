using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    private float percOrig = 0.98f;
    private float fieldForce = 15.0f;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 newVel = (transform.up * fieldForce) * (1.0f - percOrig);
            Vector2 oldVel = rb.velocity * percOrig;
            rb.velocity = newVel + oldVel;
        }
       
    }


}
