using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRepeatedly());
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
            }
            else
            {
                Debug.Log("Please set contained spawn");
            }
            Rigidbody2D rb = newGO.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * Random.Range(minForce, maxForce));
        }
    }




}
