using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    Rigidbody2D rb;
    public int deathDelay = 1;
    public GameObject explosionPrefab;
    public float waitTilRocketLive = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitThenEnableHitPlayer());
    }

    public void FixedUpdate()
    {
        rb.velocity = transform.right * 10.0f;
    }


    public  Rigidbody2D GetRB()
    {
        return rb;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        RocketDeflect rdScript = other.gameObject.GetComponent<RocketDeflect>();
        Health healthForPlayer = other.gameObject.GetComponent<Health>();

        if (rdScript)
        {
            rdScript.DeflectShot(this);
        }
        else
        {
            if (healthForPlayer)
            {
                healthForPlayer.DealDamage();
            }
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }

    IEnumerator WaitThenEnableHitPlayer()
    {
        yield return new WaitForSeconds(waitTilRocketLive);
        gameObject.layer = 0;
    }

}
