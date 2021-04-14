using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFireball : MonoBehaviour
{
    public static SpawnerFireball instance;

    public Transform newSpawn;
    public GameObject prefabToSpawn;
    public float minSpawnDelay = 2f;
    public float maxSpawnDelay = 5f;
    public float destroyTime = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRepeatedly());
    }

    IEnumerator SpawnRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            {
                GameObject newGO = GameObject.Instantiate(prefabToSpawn);
                if (newSpawn != null)
                {
                    newGO.transform.SetParent(newSpawn);
                    newGO.transform.position = newSpawn.transform.position;
                    Destroy(newGO, destroyTime);
                }
                else
                {
                    Debug.Log("Please set contained spawn");
                }
            }
        }
    }
}
