using System.Collections;
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

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, deathDelay);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyObjectDelayed();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Debug.Log("Enemy Hit");
        }

    }


}
