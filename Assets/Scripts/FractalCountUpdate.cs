using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FractalCountUpdate : MonoBehaviour
{
    public static FractalCountUpdate instance;

    public int fractalCount = 0;
    Text displayText;

    private void Awake()
    {
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
