using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    Rigidbody2D rb;
        public int deathDelay = 1;
    
    
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

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, deathDelay);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        DestroyObjectDelayed();
        {
            Destroy(gameObject, deathDelay);
        }

        if (CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
        }

    }


}
