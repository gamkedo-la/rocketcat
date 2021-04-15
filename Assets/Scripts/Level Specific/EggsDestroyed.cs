using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsDestroyed : MonoBehaviour
{
    public Transform eggSpawn;
    public static EggsDestroyed instance;
    public GameObject warperToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        MakeWarpers();
    }


    public void DestroyEggs()
    {
        //MakeWarpers();
        Destroy(gameObject);
    }


    public void MakeWarpers()
    {
        {
            GameObject newGO = GameObject.Instantiate(warperToSpawn);
            if (eggSpawn != null)
            {
                newGO.transform.SetParent(eggSpawn);
                newGO.transform.position = eggSpawn.transform.position;
                EnemyCountUpdate.instance.EnemyIncrease();
            }
            else
            {
                Debug.Log("Please set contained spawn");
            }
        }
    }
}
