using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDoorFinal : MonoBehaviour
{
    [Header("Material")]
    [SerializeField] Material doorOpen;
    [SerializeField] Material doorClose;


    [Header("Sound")]
    [SerializeField] AudioClip doorOpened;
    [SerializeField] [Range(0, 1)] public float soundVolume = 0.7f;

    
  
    private void Start()
    {
        doorClose = Resources.Load<Material>("doorClose");
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
    }


    public void DoorColorChange()
    {
        if (EnemyCountUpdate.instance.AllEnemiesAreDefeated())
        {
            WinDoorOpenLights.instance.DoorOpenGreenLight();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && EnemyCountUpdate.instance.AllEnemiesAreDefeated())
        {
            if (FractalCoinCountUpdate.fractalCoinCount >= 1000)
            {
                AudioSource.PlayClipAtPoint(doorOpened, Camera.main.transform.position, soundVolume);
                Destroy(other.gameObject);
                SceneManager.LoadScene("Win Screen Best");
            }
            if(FractalCoinCountUpdate.fractalCoinCount >= 500 && FractalCoinCountUpdate.fractalCoinCount < 1000)
            {
                AudioSource.PlayClipAtPoint(doorOpened, Camera.main.transform.position, soundVolume);
                Destroy(other.gameObject);
                SceneManager.LoadScene("Win Screen Better");
            }
            else
            {
                AudioSource.PlayClipAtPoint(doorOpened, Camera.main.transform.position, soundVolume);
                Destroy(other.gameObject);
                SceneManager.LoadScene("Win Screen Good");
            }
        }
    }


    public void Update()
    {
        DoorColorChange();
    }
}
