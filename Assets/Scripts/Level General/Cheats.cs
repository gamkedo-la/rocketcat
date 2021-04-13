using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    private static Cheats instance;

    [SerializeField] private Health playerHealth;    
    [SerializeField] private PlayerController playerController;
    [SerializeField] private RocketCountUpdate rocketCountUpdate;
    [SerializeField] private Transform teleportTo;

    private bool cheatsEnabled = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("Cheats enabled: " + cheatsEnabled);
        Debug.Log("Backslash key to toggle cheats");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            cheatsEnabled = !cheatsEnabled;
            Debug.Log("Cheats enabled: " + cheatsEnabled);
        }

        if (cheatsEnabled == false)
        {
            return;
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

        if (Input.GetKeyDown(KeyCode.N))
        {
            FractalCoinCountUpdate.instance.UpdateCoinFractalCountCheat();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < 5; i++)
            {
                playerHealth.DealDamage(true);
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
