using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : MonoBehaviour
{
    public WarpGate destination;
    public Color debugLine;
    public float lockOutTimer = 0.0f;

    public void OnDrawGizmos()
    {
        if(destination == null)
        {
            return;
        }
        Gizmos.color = debugLine;
        Gizmos.DrawLine(transform.position + Vector3.up, destination.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(destination == null)
        {
            Debug.Log("destination is null. teleporter does not have destination inside");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lockOutTimer > 0.0f)
        {
            lockOutTimer -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && lockOutTimer <= 0.0f)
        {
            destination.lockOutTimer = 1.0f;
            other.gameObject.transform.position = destination.transform.position;
        }
    }

}
