using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RocketCountUpdate : MonoBehaviour
{
    public static RocketCountUpdate instance;

    public static int rocketCount = 8;
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
        displayText = gameObject.GetComponent<Text>();
        displayText.text = rocketCount + "/" + rocketLimit;
        UpdateCounter(false);
    }


    public void UpdateCounter(bool rocketAmmoAtLimit)
    {
        Debug.Log("Fired Rocket");
        if (rocketAmmoAtLimit)
        {
            rocketCount--;
        }
        displayText.text = rocketCount + "/" + rocketLimit;
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
