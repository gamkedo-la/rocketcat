using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCountUpdate : MonoBehaviour
{
    public static EnemyCountUpdate instance;
    int startCount;
    Text displayText;
    GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
    public float enemyWinValue = 0f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        startCount = enemyList.Length;
        displayText = gameObject.GetComponent<Text>();
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        Debug.Log("Updating Counter");
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        int countNow = enemyList.Length;
        displayText.text = countNow + "/" + startCount;
    }
 

    public void UpdateCounterNextFrame()
    {
        StartCoroutine(WaitFrameForUI());
    }

    IEnumerator WaitFrameForUI()
    {
        yield return new WaitForEndOfFrame();
        UpdateCounter();
    }
}
