using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    private void Start()
    {
        GameObject.Find("Rocket Launcher").SetActive(true);
        GameObject.Find("Rocket Launcher Alien").SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            GameObject.Find("Rocket Launcher").SetActive(true);
            GameObject.Find("Rocket Launcher Alien").SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            GameObject.Find("Rocket Launcher Alien").SetActive(true);
            GameObject.Find("Rocket Launcher").SetActive(false);
            
        }


    }
}
