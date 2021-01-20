using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCountUpdate : MonoBehaviour
{
    public static EnemyCountUpdate instance;
    public float enemyWinValue = 0f;
    int startCount;
    int currentCount;
    Text displayText;

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
        if(removedTarget)
        {
            currentCount--;
        }
        if (currentCount == 1)
        {
            GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            EdgeArrows.pointAt = enemyList[0].transform;
        }
        displayText.text = "Enemies: " + (startCount - currentCount) + "/" + startCount;
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
