using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDoor : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void DoorColorChange()
    {
        if (EnemyCountUpdate.instance.AllEnemiesAreDefeated())
        {
            var doorColor = gameObject.GetComponent<Renderer>();
            doorColor.material.SetColor("_Color", Color.green);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && EnemyCountUpdate.instance.AllEnemiesAreDefeated())
        {
            LoadNextScene();
        }
    }

    public void Update()
    {
        DoorColorChange();
    }

}
