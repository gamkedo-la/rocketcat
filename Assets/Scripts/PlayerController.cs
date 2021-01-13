using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] int rocketJumpForce = 10;
    bool isOnGround = false;

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
        float jumpSpeed = 10f;
        int groundMask = ~LayerMask.GetMask("Player", "PlayerShot", "Explosions"); //detect anything but these  
        isOnGround = Physics2D.OverlapCircleAll(transform.position + Vector3.down, 0.49f, groundMask).Length > 0;

        //Keys That Aren't Held 
        if (Input.GetKeyDown("space"))
        {
            if (isOnGround)
            {
                rb.velocity += new Vector2(0.0f, jumpSpeed);
            }
        }
        else if (Input.GetKeyUp("space"))
        {
            float capVerticalSpeedToFall = 3.5f;
            if (rb.velocity.y > capVerticalSpeedToFall)
            {
                rb.velocity = new Vector2(rb.velocity.x, capVerticalSpeedToFall);
            }
        }
    }

    private void PlayerMovement()
    {
        float hSpeed = 0.1f;

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity += new Vector2(hSpeed, 0.0f);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity += new Vector2(-hSpeed, 0.0f);
        }
    }
}
