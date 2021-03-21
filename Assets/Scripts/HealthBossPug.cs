using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBossPug : MonoBehaviour
{
    Material bossMat;
    [SerializeField] Material bossHurt;
    [SerializeField] int health = 30;


    // Start is called before the first frame update
    void Start()
    {
        bossMat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool DealDamage(bool invulOverride = false)
    {
        health--;
        EnemyBossDamageFlash.instance.DamageFlash();
        if (health <= 0)
        {
            Destroy(gameObject);
            EnemyCountUpdate.instance.RemoveFromCounterNextFrame();
        }
        return true;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            DealDamage();
        }
    }

}
