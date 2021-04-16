using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public bool destroyParentAlso = false;

    public int HP = 1;

    public GameObject spawnOnHit;
    public GameObject spawnOnDestroy;
    
    public void DestroySelf() // called every time an explosion touches this
    {
        HP--;
        if (HP<1) {

            if (spawnOnDestroy) Instantiate(spawnOnDestroy, transform.position, Quaternion.identity);

            // next three lines used in level 16 for destroyed eggs
            EggsDestroyed eggScript = gameObject.GetComponent<EggsDestroyed>();
            if (eggScript)
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
        
        } else { // not dead yet
        
            Debug.Log(gameObject.name+" HP: "+HP);
            if (spawnOnHit) Instantiate(spawnOnHit, transform.position, Quaternion.identity);
            EnemyBossFinaleDamageFlash flasher = GetComponentInChildren<EnemyBossFinaleDamageFlash>();
            if (flasher)
                flasher.DamageFlash();
            else
                Debug.Log("nothing to flash red!");
        }
    }
}
