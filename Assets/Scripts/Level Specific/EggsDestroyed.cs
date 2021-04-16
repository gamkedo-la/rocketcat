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
        {
            GameObject newGO = GameObject.Instantiate(warperToSpawn);
            if (newGO != null)
            {
                newGO.transform.SetParent(null);
                newGO.transform.position = transform.position;
                EnemyCountUpdate.instance.EnemyIncrease();
            }
            else
            {
                Debug.Log("Object failed to spawn");
            }
        }
    }
}
