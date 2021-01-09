using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionMultiplier = 1000.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
        Collider2D[] pushStuff = Physics2D.OverlapCircleAll(transform.position, 2.0f);
        for (int i = 0; i < pushStuff.Length; i++)
        {
            Rigidbody2D rb = pushStuff[i].GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.AddForce((rb.transform.position - transform.position) * explosionMultiplier);
            }
        }
    }

   
}
