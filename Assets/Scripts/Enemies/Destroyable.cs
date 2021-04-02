using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public bool destroyParentAlso = false;

  public void DestroySelf()
    {
        if (gameObject.CompareTag("Spawner"))
        {
            Destroy(Spawner.instance.prefabToSpawn);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (destroyParentAlso)
        {
            Destroy(transform.parent.gameObject);
        }
        EnemyCountUpdate.instance.RemoveFromCounterNextFrame();
    }
    


}
