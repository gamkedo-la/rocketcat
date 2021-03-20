using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FractalCoinCountUpdate : MonoBehaviour
{
    public static FractalCoinCountUpdate instance;

    public static int enteredLevelWith = 0;
    public static int fractalCoinCount;
    Text displayText;


    private void Awake()
    {
        fractalCoinCount = enteredLevelWith;
        instance = this;
    }

    private void Start()
    {
        displayText = gameObject.GetComponent<Text>();
        displayText.text = fractalCoinCount.ToString();
    }


    public void UpdateCoinFractalCount()
    {
        fractalCoinCount++;
        displayText.text = fractalCoinCount.ToString();
    }


}
