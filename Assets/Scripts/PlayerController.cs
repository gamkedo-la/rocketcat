using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] int rocketJumpHeight = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        PlayerMovement();
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
        else if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector3(rb.velocity.x, rocketJumpHeight, 0);
        }
    }
}
