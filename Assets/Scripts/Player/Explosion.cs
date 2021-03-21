using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionRadius = 2.0f;
    public float coRadius = 1.0f;
    public float timeBeforeDestructionParticlesFinish = 2.0f;
    public float explosionMultiplier = 1000.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeBeforeDestructionParticlesFinish);
        Collider2D[] pushStuff = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        for (int i = 0; i < pushStuff.Length; i++)
        {
            Rigidbody2D rb = pushStuff[i].GetComponent<Rigidbody2D>();
            if (rb)
            {
                if (rb.velocity.y < 0.0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                }
                Vector3 pushFrom = transform.position + Vector3.up * -1.5f;
                rb.AddForce((rb.transform.position - pushFrom).normalized * explosionMultiplier);
                PlayerController pc = pushStuff[i].GetComponent<PlayerController>();
                if(pc)
                {
                    pc.BumpedByRocket();
                }
            }
        }
        Collider2D[] killStuff = Physics2D.OverlapCircleAll(transform.position, coRadius);
        for (int i = 0; i < killStuff.Length; i++)
        {
            Destroyable dScript = killStuff[i].GetComponent<Destroyable>();
            if (dScript)
            {
                dScript.DestroySelf();
            }
        }
    }

   
}
