using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private CheckpointMaster cm;
    private Health healthScript;
    private RocketCountUpdate rocketScript;
    

    // Start is called before the first frame update
    public void ResetPlayer()
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
        transform.position = cm.lastcheckpointpos;
        Health.instance.ResetHealth();
        RocketCountUpdate.instance.RocketReset();
    }


}
