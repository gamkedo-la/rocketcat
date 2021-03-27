using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float gravPower = 50.0f;
    private float gravityRadius;

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
            Vector2 direction = transform.position - other.transform.position;
            direction.Normalize();
            rb.AddForce(direction * power * gravPower);
        }
    }

}
