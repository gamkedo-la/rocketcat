using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartText : MonoBehaviour
{
    private RocketCountUpdate rcu;


    // Start is called before the first frame update
    void Start()
    {
        rcu = GameObject.FindGameObjectWithTag("RocketsLeft").GetComponent<RocketCountUpdate>();
        gameObject.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rcu.rocketCount <= rcu.rocketLimit)
        {
            gameObject.GetComponent<Text>().enabled = true;
        }

        else
            gameObject.GetComponent<Text>().enabled = false;
    }
}
