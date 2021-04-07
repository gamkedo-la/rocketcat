using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private Health healthScript;
    private RocketCountUpdate rocketScript;


    private void Start()
    {
        CheckpointMaster.instance.lastcheckpointpos = transform.position;
    }

    // Start is called before the first frame update
    public void ResetPlayer()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        transform.position = CheckpointMaster.instance.lastcheckpointpos;
        Health.instance.ResetHealth();
        RocketCountUpdate.instance.RocketReset();
    }


}
