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
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(2, rb.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-2, rb.velocity.y);
        }
        //Regular Jump
        else if (Input.GetKey("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 1);
        }
        //Rocket Jump
        else if (clickDetected)
        {
            clickDetected = false;
            rb.velocity = new Vector2(rb.velocity.x, rocketJumpForce);
            Debug.Log(rb.velocity);
        }
    }
}
