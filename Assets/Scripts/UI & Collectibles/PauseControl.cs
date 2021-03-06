﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    [Range(0.1f, 1f)] [SerializeField] float gameSpeedActive = 1f;
    [Range(0f, 0f)]  [SerializeField] float gameSpeedPaused = 0f;


    public static bool gameIsPaused;

    private void Start()
    {
        gameObject.GetComponent<Text>().enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadStartMenu();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameIsPaused = !gameIsPaused;
                PauseGame();
                LoadStartMenu();
            }
        }
    }


    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = gameSpeedPaused;
            gameObject.GetComponent<Text>().enabled = true;
        }
        else
        {
            Time.timeScale = gameSpeedActive;
            gameObject.GetComponent<Text>().enabled = false;
        }
    }


    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

}
