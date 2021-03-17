using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienHeartCountUpdate : MonoBehaviour
{
    public static AlienHeartCountUpdate instance;

    public static int enteredLevelWith = 0;
    public static int alienHeartCount;
    Text displayText;


    private void Awake()
    {
        alienHeartCount = enteredLevelWith;
        instance = this;
    }

    private void Start()
    {
        displayText = gameObject.GetComponent<Text>();
        displayText.text = alienHeartCount.ToString();
    }


    public void UpdateAlienHeartCount()
    {
        alienHeartCount++;
        displayText.text = alienHeartCount.ToString();
    }


}
