using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCountUpdate : MonoBehaviour
{
    public static EnemyCountUpdate instance;
    int startCount;
    int currentCount;
    Text displayText;
    public float enemyWinValue = 0f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        currentCount = startCount = enemyList.Length;
        displayText = gameObject.GetComponent<Text>();
        UpdateCounter(false);
    }

    public bool AllEnemiesAreDefeated()
    {
        return currentCount == 0;
    }

    public void UpdateCounter(bool removedTarget)
    {
        Debug.Log("Updating Counter");
        if(removedTarget)
        {
            currentCount--;
        }
        displayText.text = "Enemies " + (startCount - currentCount) + "/" + startCount;
    }
 

    public void RemoveFromCounterNextFrame()
    {
        StartCoroutine(WaitFrameForUI());
    }

    IEnumerator WaitFrameForUI()
    {
        yield return new WaitForEndOfFrame();
        UpdateCounter(true);
    }
}
