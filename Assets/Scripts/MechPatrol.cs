using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public Animator animator;

    public float speed;
    public float distance = 2f;
    public bool mustPatrol;
    private bool movingLeft = true;

    public Rigidbody2D rb;
    public Transform groundDetection;
    public LayerMask obstacleLayer;
    public LayerMask enemyLayer;
    public Collider2D bodyCollider;

    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol(); 
        }

        /*var waypointReached = true;
        if (waypoints.Length == 0 || waypointReached)
        {
            animator.SetTrigger("WaypointReached");
        }*/
    }




    void Patrol()
    { 
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (bodyCollider.IsTouchingLayers(obstacleLayer) || bodyCollider.IsTouchingLayers(enemyLayer))
        {
            Flip();
        }

        if (groundInfo.collider == false)
        {
            if(movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }

    }



    //not currently in use- used transform.eulerAngles above instead 
    void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        speed *= -1;
    }

}
