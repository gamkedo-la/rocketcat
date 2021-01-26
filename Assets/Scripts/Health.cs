using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    Material playerMat;
    [SerializeField] Material playerHurt;
    [SerializeField] int health = 5;
    private float pushMultiplier = 250f;
    Rigidbody2D rb;
    bool invulnTime = false;

    private void Start()
    {
        playerMat = gameObject.GetComponent<Renderer>().material;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public bool DealDamage()
    {
        if (invulnTime)
        {
            return false;
        }
        health--;
        StartCoroutine(DamageFlash());
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.DelayThenLoadScene(false);
        }
        return true;
    }

    IEnumerator DamageFlash()
    {
        invulnTime = true;
        GetComponent<MeshRenderer>().material = playerHurt;
        yield return new WaitForSeconds(1.0f);
        GetComponent<MeshRenderer>().material = playerMat;
        invulnTime = false;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (DealDamage())
            {
                Vector3 pushFrom = transform.position + Vector3.up * -1.5f;
                rb.AddForce((rb.transform.position - pushFrom).normalized * pushMultiplier);
                //PlayerController pc = gameObject.GetComponent<PlayerController>();
            }

        }
    }

}
