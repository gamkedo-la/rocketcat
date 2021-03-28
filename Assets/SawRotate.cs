using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    public bool doesRotate;
    public bool rotateCounterClockwise;
    public float rotateSpeed = 10f;

    private int directionNum = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (rotateCounterClockwise)
            directionNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(doesRotate)
        transform.Rotate(Vector3.up * Time.deltaTime * directionNum * rotateSpeed);
    }
}
