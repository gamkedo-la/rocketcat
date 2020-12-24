using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStart : MonoBehaviour
{
    public Transform testTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(testTarget);
        float ang = Mathf.Atan2(testTarget.position.y - transform.position.y, testTarget.position.x - transform.position.x);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, ang * Mathf.Rad2Deg);
    }
}
