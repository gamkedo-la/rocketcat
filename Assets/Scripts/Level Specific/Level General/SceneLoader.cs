using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadCredits()
        {
        SceneManager.LoadScene("Credits Menu");
        }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options Menu");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
