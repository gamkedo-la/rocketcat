using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsor : MonoBehaviour
{
    private float gravityRadius;
    public float gravForce = 200.0f;

    private void Start()
    {
        CircleCollider2D myCollider = GetComponent<CircleCollider2D>();
        gravityRadius = myCollider.radius;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float dist = Vector3.Distance(other.transform.position, transform.position);
            float power = 1.0f - (dist / gravityRadius);
            power *= power;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 direction = other.transform.position - transform.position;
            direction.Normalize();
            rb.AddForce(direction * power * gravForce);
        }
    }
}
