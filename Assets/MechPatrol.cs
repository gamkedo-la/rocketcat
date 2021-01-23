using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var waypointReached = true;

        if (waypoints.Length == 0 || waypointReached)
        {
            animator.SetTrigger("WaypointReached");
        }
    }
}
