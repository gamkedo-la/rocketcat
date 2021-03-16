using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform newSpawn;
    public GameObject prefabToSpawn;
    public float minSpawnDelay = 2f;
    public float maxSpawnDelay = 3.5f;





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
            GameObject newGO = GameObject.Instantiate(prefabToSpawn);
            if (newSpawn != null)
            {
                newGO.transform.SetParent(newSpawn);
                EnemyCountUpdate.instance.EnemyIncrease();
            }
            else
            {
                Debug.Log("Please set contained spawn");
            }
        }
    }
}
