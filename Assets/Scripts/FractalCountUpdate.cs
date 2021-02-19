using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FractalCountUpdate : MonoBehaviour
{
    public static FractalCountUpdate instance;

    public int fractalCount;
    Text displayText;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
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
