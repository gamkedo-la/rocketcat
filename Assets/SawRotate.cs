using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    public bool doesRotate;
    public float rotateSpeed = 10f;

    private int directionNum = -1;

    // Update is called once per frame
    void Update()
    {
        if(doesRotate)
        transform.Rotate(Vector3.up * Time.deltaTime * directionNum * rotateSpeed);
    }
}
