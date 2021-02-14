using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{   
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    private RocketCountUpdate rocketCountUpdate;

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (playerHealth.ToggleInvincible())
            {
                Debug.Log("Toggled invincible on!");
            }
            else
            {
                Debug.Log("Toggled invincible off!");
            }
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            rocketCountUpdate.RocketReset();
        }
    }
}
