﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketStart : MonoBehaviour
{
    public Transform testTarget;
    public GameObject rocketPrefab;
    public Transform rocketFrom;

    [Header ("Sound")]
    [SerializeField] AudioClip rocketExplodeSound;
    [SerializeField] [Range (0,1)] public float soundVolume = 0.7f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        RocketCreated();
    }

    private void RocketCreated()
    {
        //transform.LookAt(testTarget);
        float ang = Mathf.Atan2(testTarget.position.y - transform.position.y, testTarget.position.x - transform.position.x);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, ang * Mathf.Rad2Deg);
        if (Input.GetMouseButtonDown(0) && (!PauseControl.gameIsPaused) && (!RocketCountUpdate.instance.RocketAmmoLimit()))
        {
            GameObject.Instantiate(rocketPrefab, rocketFrom.position, rocketFrom.rotation, null);
            AudioSource.PlayClipAtPoint(rocketExplodeSound, Camera.main.transform.position, soundVolume);
            RocketCountUpdate.instance.AddFromCounterNextFrame();
        }
    }

}
