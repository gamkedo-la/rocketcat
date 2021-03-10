﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{   
    [SerializeField] private Health playerHealth;    
    [SerializeField] private PlayerController playerController;
    [SerializeField] private RocketCountUpdate rocketCountUpdate;
    [SerializeField] private Transform teleportTo;

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.R))
            //not a cheat, player controlled, should be in player controller 
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
        if(Input.GetKeyDown(KeyCode.K))
        {
            EnemyCountUpdate.instance.KillAllEnemies();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(teleportTo != null)
            {
                PlayerController.instance.transform.position = teleportTo.position;
            }
            else
            {
                Debug.Log("Tried to teleport to, but no teleport defined");
            }
        }

        if (Input.GetKeyUp(KeyCode.G)) 
        {
            if (playerController.Rb.gravityScale > 0) 
            {
                Debug.Log("Toggled gravity off! Use WASD keys to move freely across the space!");
                playerController.Rb.gravityScale = 0;
            }
            else
            {
                Debug.Log("Toggled gravity on! Can no longer freely move up or down!");
                playerController.Rb.gravityScale = 1;
            }
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
            Debug.Log("Reset number of rockets left!");
        }
    }
}
