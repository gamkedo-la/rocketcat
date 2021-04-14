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
            // don't kill the boss! only regular baddies
            if (!other.gameObject.name.Contains("Boss")) {
                EnemyCountUpdate.instance.UpdateCounter(true);
                Destroy(other.gameObject);
            }
        }

        if (!other.gameObject.CompareTag("Player"))
            return;

        //used to reload the player back to the start of the current level
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);

        //code for last checkpoint for player
        PlayerPos ppScript = PlayerController.instance.GetComponent<PlayerPos>();
        ppScript.ResetPlayer();

        //use commented out code below (and comment out above code) to make player reload from beginning of game
        //SceneManager.LoadScene("Fail Screen"); 
    }



}
