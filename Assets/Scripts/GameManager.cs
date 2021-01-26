using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int sceneToLoad;

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
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneToLoad);
    }

}
