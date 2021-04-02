using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDestroyable : MonoBehaviour
{
    
    public void DestroySelf()
    {

            Destroy(Spawner.instance.prefabToSpawn);
            EnemyCountUpdate.instance.RemoveFromCounterNextFrame();
            Destroy(gameObject);
            EnemyCountUpdate.instance.RemoveFromCounterNextFrame();
    }




}
