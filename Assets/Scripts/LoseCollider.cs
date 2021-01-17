using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyCountUpdate.instance.UpdateCounter(true);
        }

        if (!other.gameObject.CompareTag("Player"))
            return;

        SceneManager.LoadScene("Fail Screen");
    }



}
