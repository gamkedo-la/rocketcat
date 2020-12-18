using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] int rocketJumpForce = 10;
    bool clickDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.velocity = new Vector3(2, rb.velocity.y, 0);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector3(-2, rb.velocity.y, 0);
        }
        //Regular Jump
        else if (Input.GetKey("space"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 1, 0);
        }
        //Rocket Jump
        else if (clickDetected)
        {
            clickDetected = false;
            rb.velocity = new Vector3(rb.velocity.x, rocketJumpForce, 0);
            Debug.Log(rb.velocity);
        }
    }
}
