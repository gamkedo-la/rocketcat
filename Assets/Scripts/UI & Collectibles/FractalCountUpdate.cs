﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FractalCountUpdate : MonoBehaviour
{
    public static FractalCountUpdate instance;

    public static int enteredLevelWith = 0;
    public static int fractalCount;
    Text displayText;


    private void Awake()
    {
        fractalCount = enteredLevelWith;
            instance = this;
    }

    private void Start()
    {
        displayText = gameObject.GetComponent<Text>();
        displayText.text = fractalCount.ToString();
    }


    public void UpdateFractalCount()
    {
        fractalCount++;
        displayText.text = fractalCount.ToString();
    }



}
