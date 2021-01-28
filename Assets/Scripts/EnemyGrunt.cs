using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrunt : MonoBehaviour
{

    public Transform player;
    public GameObject projectile;
    public Transform laserFrom;
    [SerializeField] GameObject laserSpawnPoint;

    [SerializeField] float minTimeBetweenShots = 2f;
    [SerializeField] float maxTimeBetweenShots = 3.5f;

    private float timeBetweenShots;
    public float startTimeBetweenShots;



    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;
        Vector3 laserFrom = laserSpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, laserFrom.position, laserFrom.rotation);
            timeBetweenShots = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
        else
        {
            timeBetweenShots -= Time.deltaTime; 
        }
    }




}
