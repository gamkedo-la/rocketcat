using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public bool destroyParentAlso = false;


    public void DestroySelf()
    {
        // next three lines used in level 16 for destroyed eggs
        EggsDestroyed eggScript = GameObject.FindGameObjectWithTag("Egg").GetComponent<EggsDestroyed>();
        if (CompareTag("Egg"))
        {
            eggScript.MakeWarpers();
            Destroy(gameObject);
            return;
        }
        //spawnlings used in level 4 to fix bug with spawners
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
