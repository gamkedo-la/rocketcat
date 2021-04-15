using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public bool destroyParentAlso = false;

  public void DestroySelf()
    {
        if (CompareTag("Egg"))
        {
            Destroy(gameObject);
            return;
        }
        Destroyable[] spawnlingsToDestroy = GetComponentsInChildren<Destroyable>();
        for(int i = 0; i < spawnlingsToDestroy.Length; i++)
        {
            if (spawnlingsToDestroy[i] != this)
            {
                spawnlingsToDestroy[i].DestroySelf();
            }
        }
        Destroy(gameObject);
        if (destroyParentAlso)
        {
            Destroy(transform.parent.gameObject);
        }
        
        EnemyCountUpdate.instance.RemoveFromCounterNextFrame();
    }
    
}
