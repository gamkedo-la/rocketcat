using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RocketCountUpdate : MonoBehaviour
{
    public static RocketCountUpdate instance;

    public static int rocketCount = 12;
    public static int rocketLimit = 0;
    public static bool rocketAmmoAtLimit = false;
    Text displayText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        RocketReset();
    }

    public void RocketReset()
    {
        rocketCount = 12;
        displayText = gameObject.GetComponent<Text>();
        displayText.text = "Rockets " + rocketCount + "/" + rocketLimit;
        UpdateCounter(false);
    }

    public void UpdateCounter(bool rocketAmmoAtLimit)
    {
        Debug.Log("Fired Rocket");
        if (rocketAmmoAtLimit)
        {
            rocketCount--;
        }
        displayText.text = "Rockets " + rocketCount + "/" + rocketLimit;
    }

    public void AddFromCounterNextFrame()
    {
        StartCoroutine(WaitFrameForUI());
    }

    IEnumerator WaitFrameForUI()
    {
        yield return new WaitForEndOfFrame();
        UpdateCounter(true);
    }

    public bool RocketAmmoLimit()
    {
        if (rocketCount == rocketLimit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
