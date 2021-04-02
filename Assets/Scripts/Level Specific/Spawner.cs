using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance; 

    public Transform newSpawn;
    public GameObject prefabToSpawn;
    public float minSpawnDelay = 2f;
    public float maxSpawnDelay = 3.5f;
    private int spawnLimitPerSpawner = 5;
    private List<GameObject> spawnList; 



    // Start is called before the first frame update
    void Start()
    {
        spawnList = new List<GameObject>();
        StartCoroutine(SpawnRepeatedly());
    }

    IEnumerator SpawnRepeatedly()
    {
        while (true)
        {
            spawnList.RemoveAll(x => !x);
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (spawnList.Count < spawnLimitPerSpawner)
            {
                GameObject newGO = GameObject.Instantiate(prefabToSpawn);
                if (newSpawn != null)
                {
                    spawnList.Add(newGO);
                    newGO.transform.SetParent(newSpawn);
                    newGO.transform.position = newSpawn.transform.position;
                    EnemyCountUpdate.instance.EnemyIncrease();
                }
                else
                {
                    Debug.Log("Please set contained spawn");
                }
            }
        }
    }
}
