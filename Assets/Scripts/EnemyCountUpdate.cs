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
    private CheckpointMaster cm;
    private int checkpointEnemyCount;

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

    //called by checkpointmaster & checkpoint scripts to reset enemy count to same as before player died
    public int EnemyCount()
    {
        return startCount - currentCount;
    }

    public void EnemyIncrease()
        {
        startCount++;
        }


    public void UpdateCounter(bool removedTarget)
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
        checkpointEnemyCount = cm.currentEnemyCount;

        if (removedTarget)
        {
            currentCount--;
        }
        if (currentCount == 1)
        {
            GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemyList.Length > 0)
            {
                EdgeArrows.pointAt = enemyList[0].transform;
            }
        }
        displayText.text = (startCount - currentCount) + "/" + startCount;
    }
 
    public void KillAllEnemies()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemyList.Length; i++)
        {
            Destroyable dScript = enemyList[i].GetComponent<Destroyable>();
            if(dScript != null)
            {
                dScript.DestroySelf();
            }
        }
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
