﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    Rigidbody2D rb;
    public int deathDelay = 1;
    public GameObject explosionPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.right * 10.0f;
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroyable dScript = other.gameObject.GetComponent<Destroyable>();
        if (dScript)
        {
            //dScript.DestroySelf(); //Happens from the explosion radius instead 
        }

    }


}
