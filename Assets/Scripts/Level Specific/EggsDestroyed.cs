using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsDestroyed : MonoBehaviour
{
    public static EggsDestroyed instance;
    public GameObject warperToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        //MakeWarpers();
    }


    public void DestroyEggs()
    {
        MakeWarpers();
        Destroy(gameObject);
    }


    public void MakeWarpers()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject newGO = GameObject.Instantiate(warperToSpawn);
            newGO.transform.SetParent(null);
            newGO.transform.position = transform.position;
            EnemyCountUpdate.instance.EnemyIncrease();
        }
    }
}
