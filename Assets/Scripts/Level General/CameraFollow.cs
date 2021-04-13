using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;


    // Update is called once per frame
    void FixedUpdate()
    {
        Transform whoToLookAt = followTransform;

        if (whoToLookAt != null)
        {
            this.transform.position = new Vector3(whoToLookAt.position.x, whoToLookAt.position.y, this.transform.position.z);
        }
    }
}
