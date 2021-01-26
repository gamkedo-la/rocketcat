using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RocketCountUpdate : MonoBehaviour
{
    public static RocketCountUpdate instance;

    List<GameObject> rocketIcons;
    public int rocketCount = 12;
    public int rocketLimit = 0;
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
        rocketIcons = new List<GameObject>();
        for (int i = 0; i < rocketCount; i++)
        {
            GameObject icon = GameObject.Find("Rocket " + (i + 1));
            rocketIcons.Add(icon);
        }
        UpdateRocketIcons();
    }

    public void RocketReset()
    {
        rocketCount = 12;
        displayText = gameObject.GetComponent<Text>();
        displayText.text = "Rockets " + rocketCount + "/" + rocketLimit;
        UpdateCounter(false);
    }

    public void UpdateRocketIcons()
    {
        for (int i = 0; i < rocketIcons.Count; i++)
        {
            rocketIcons[i].SetActive(i < rocketCount);
        }
    }

    public void UpdateCounter(bool rocketAmmoAtLimit)
    {
        if (rocketAmmoAtLimit)
        {
            rocketCount--;
            UpdateRocketIcons();
        }

        displayText.text = "Rockets: " + rocketCount;
    }


    private void Update()
    {
        RocketAmmoLimit();
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
