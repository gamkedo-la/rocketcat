using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartText : MonoBehaviour
{
    private RocketCountUpdate rcu;



    private void Start()
    {
        gameObject.GetComponent<Text>().enabled = false;
    }

    private void Update()
    {
        ShowRestartText();
    }



    void ShowRestartText()
    {
        if (rcu.RocketAmmoLimit() == true)
        {
            gameObject.GetComponent<Text>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Text>().enabled = false;
        }
    }
}
