using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private CheckpointMaster cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<CheckpointMaster>();
        transform.position = cm.lastcheckpointpos;
    }


}
