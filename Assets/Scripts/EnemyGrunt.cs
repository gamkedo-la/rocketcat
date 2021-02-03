using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrunt : MonoBehaviour
{
    [Header("Fire Projectile")]
    public GameObject projectile;
    public Transform laserFrom;
    [SerializeField] GameObject laserSpawnPoint;
    [SerializeField] float minTimeBetweenShots = 2f;
    [SerializeField] float maxTimeBetweenShots = 3.5f;
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    [SerializeField] [Range(0, 1)] float fireSoundVol = 1f;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShots = startTimeBetweenShots;
        Vector3 laserFrom = laserSpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }


    public void Fire()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < 20.0f)
        {
            if (timeBetweenShots <= 0)
            {
                Instantiate(projectile, laserFrom.position, laserFrom.rotation);
                timeBetweenShots = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
                audioSource.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
                audioSource.PlayOneShot(audioSource.clip, fireSoundVol);
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }
}
