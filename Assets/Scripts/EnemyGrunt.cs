﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrunt : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;
    public GameObject projectile;

    private float timeBetweenShots;
    public float startTimeBetweenShots;




    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, player.rotation);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime; 
        }
    }










    /* Below Function not currently in use
    private void FollowPlayer()
    {
        //if too far away from player, enemy will advance toward player
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //in the sweet spot not too close or far from the player, enemy stays put 
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }*/

}
