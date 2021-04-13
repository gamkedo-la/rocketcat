﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWithForce : MonoBehaviour
{
    public Transform containedSpawned;
    public GameObject prefabToSpawn;
    public float minSpawnDelay = .2f;
    public float maxSpawnDelay = 1.0f;
    public float minForce = 100f;
    public float maxForce = 600f;
    public float minReloadSpawnDelay = 3.0f;
    public float maxReloadSpawnDelay = 7.0f;
    public GameObject reloadCrateToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        if (prefabToSpawn!=null)
            StartCoroutine(ShootRepeatedly());
        
        if (reloadCrateToSpawn!=null)
            StartCoroutine(ShootReloadCrateRepeatedly());
    }

    // Update is called once per frame
    IEnumerator ShootRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            GameObject newGO = GameObject.Instantiate(prefabToSpawn);
            if(containedSpawned != null)
            {
                newGO.transform.SetParent(containedSpawned);
                newGO.transform.position = transform.position; // of the spawner
            }
            else
            {
                Debug.Log("Please set contained spawn");
            }
            Rigidbody2D rb = newGO.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * Random.Range(minForce, maxForce));
            if (Random.value>0.5f) {
                rb.AddForce(transform.right * -1 * Random.Range(minForce, maxForce));
            } else {
                rb.AddForce(transform.right * Random.Range(minForce, maxForce));
            }
        }
    }

    IEnumerator ShootReloadCrateRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minReloadSpawnDelay, maxReloadSpawnDelay));
            GameObject newGO = GameObject.Instantiate(reloadCrateToSpawn);
            if (containedSpawned != null)
            {
                newGO.transform.SetParent(containedSpawned);
                newGO.transform.position = transform.position; // of the spawner
            }
            else
            {
                Debug.Log("Please set contained spawn");
            }
            Rigidbody2D rb = newGO.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * Random.Range(minForce, maxForce));
            if (Random.value>0.5f) {
                rb.AddForce(transform.right * -1 * Random.Range(minForce, maxForce));
            } else {
                rb.AddForce(transform.right * Random.Range(minForce, maxForce));
            }
        }
    }


}
