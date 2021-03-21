using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDoor : MonoBehaviour
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


    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
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
            FractalCountUpdate.enteredLevelWith = FractalCountUpdate.fractalCount;
            AlienHeartCountUpdate.enteredLevelWith = AlienHeartCountUpdate.alienHeartCount;
            AudioSource.PlayClipAtPoint(doorOpened, Camera.main.transform.position, soundVolume);
            Destroy(other.gameObject);
            GameManager.instance.DelayThenLoadScene(true);
        }
    }


    public void Update()
    {
        DoorColorChange();
    }

}
