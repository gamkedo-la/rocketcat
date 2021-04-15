using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int sceneToLoad;
    public Animator transition;


    private void Awake()
    {
        PauseMenu.gamePaused = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    public void DelayThenLoadScene(bool nextStage)
    {
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        if(nextStage)
        {
            sceneToLoad++;
        }
        StartCoroutine(WaitForLoad());
    }

    IEnumerator WaitForLoad()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneToLoad);
    }

    //these two functions below allow a sound to finish playing before executing next line of code
    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void PlaySound()
    {
        WaitForSound();
    }

}
