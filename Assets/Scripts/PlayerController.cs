using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] int rocketJumpForce = 10;
    bool clickDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        PlayerMovement();
    }


    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            clickDetected = true;
        }
    }

    private void PlayerMovement()
    {
        float hSpeed = 0.1f;
        float jumpSpeed = 1f;


        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity += new Vector2(hSpeed, 0.0f);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity += new Vector2(-hSpeed, 0.0f);
        }
        //Regular Jump
        else if (Input.GetKey("space"))
        {
            rb.velocity += new Vector2(0.0f, jumpSpeed);
        }
        //Rocket Fired
        if (clickDetected)
        {
            clickDetected = false;
        }
    }
}
