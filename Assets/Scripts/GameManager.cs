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

    //bool used for muting/unmuting the game
    private bool isMuted = false;


    private void Awake()
    {
        PauseMenu.gamePaused = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    void Update()
    {
        //if the player presses the M key, the ToggleMute function will run (used for muting/unmuting)
        if(Input.GetKeyDown(KeyCode.M))
        ToggleMute();
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



  
    //Will flip the current bool value for isMuted and then will pause or unpause the audiolistener based on the isMuted value
    public void ToggleMute()
    {
        isMuted = !isMuted;

        AudioListener.pause = isMuted;
    }


}
