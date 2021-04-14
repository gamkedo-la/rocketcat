using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public bool isVertical = false;
    public float speed = 1f;

    private Rigidbody2D rb;
    private Vector3 startPos;
    private Vector3 offsetVec;

    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        UpdateVector();
    }

    void UpdateVector()
    {
        if (isVertical)
        {
            offsetVec = Vector3.up;
        }
        else
        {
            offsetVec = Vector3.right;
        }
    }



    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
    }
}
