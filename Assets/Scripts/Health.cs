using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] Material player;
    [SerializeField] Material playerHurt;

    [SerializeField] float health = 5f;
    private float damage = 1f; 

    public void DealDamage(float damage)
    {
        GetComponent<MeshRenderer>().material = playerHurt;
        health -= damage;
        GetComponent<MeshRenderer>().material = player;
        if (health <= 0)
            Destroy(gameObject);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            DealDamage(damage);
    }

    private void Update()
    {
        
    }


}
