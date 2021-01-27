using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public Animator animator;

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        var waypointReached = true;
        if (waypoints.Length == 0 || waypointReached)
        {
            animator.SetTrigger("WaypointReached");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            gameObject.transform.Rotate(0, 180, 0);
        }
        else
        {
            return;
        }
    }




}
