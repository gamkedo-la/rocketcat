using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public GameObject rocketLauncher;
    public GameObject alienRocketLauncher;

    public GameObject rocketCatModel;
    public GameObject rocketCatModelFlipped; 
   
    private Rigidbody2D rb;
    public Rigidbody2D Rb
    {
        get {
            return rb;
        }
    } 

    bool isOnGround = false;
    bool rocketBumped = false;
    bool debugFakeSpacebar = false;
    bool debugFakeSpacebarRelease = false; 
    //Vector2 velWhenBumped = Vector2.zero;
    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    public void BumpedByRocket()
    {
       /* if(rocketBumped == false)
        {
            rb.velocity = velWhenBumped;
        }*/
        rocketBumped = true;
    }

    private void Update()
    {
        float jumpSpeed = 10f;
        int groundMask = ~LayerMask.GetMask("Player", "PlayerShot", "Explosions"); //detect anything but these  
        isOnGround = Physics2D.OverlapCircleAll(transform.position + Vector3.down * 0.6f, 0.49f, groundMask).Length > 0;

        //Keys That Aren't Held 
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }


        if (Input.GetKeyDown("space") || debugFakeSpacebar)
        {
            if (isOnGround)
            {
                rb.velocity += new Vector2(0.0f, jumpSpeed);
                rocketBumped = false;
                //velWhenBumped = Vector2.zero;
            }
        }
        else if ((Input.GetKeyUp("space") || debugFakeSpacebarRelease)  && rocketBumped == false)
        {
            debugFakeSpacebarRelease = false;
            /*float capVerticalSpeedToFall = 10f;
            if (rb.velocity.y > capVerticalSpeedToFall)
            {
                //velWhenBumped = rb.velocity;
                rb.velocity = new Vector2(rb.velocity.x, capVerticalSpeedToFall);
            }//if rb*/
        }//else if
        else if (Input.GetKeyDown("1"))
        {
            Debug.Log("Weapon Switch");
            rocketLauncher.SetActive(rocketLauncher.activeSelf == false);
            alienRocketLauncher.SetActive(rocketLauncher.activeSelf == false);
        }

        /*else if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(TestRocketBug());
        }*/
    }// update

    IEnumerator TestRocketBug()
    {
        debugFakeSpacebar = true;
        yield return new WaitForSeconds(0.1f);
        RocketStart.debugFireDown = true;
        yield return new WaitForSeconds(0.1f);
        debugFakeSpacebar = false;
        debugFakeSpacebarRelease = true;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }


    private void PlayerMovement()
    {
        float hSpeed = 0.1f;
        float vSpeed = 0.1f;

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity += new Vector2(hSpeed, 0.0f);
            rocketCatModel.SetActive(true);
            rocketCatModelFlipped.SetActive(false);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {

            rb.velocity += new Vector2(-hSpeed, 0.0f);
            rocketCatModel.SetActive(false);
            rocketCatModelFlipped.SetActive(true);
        }

        if (rb.gravityScale == 0) 
        {
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                rb.velocity += new Vector2(0.0f, vSpeed);
            }
            else if (Input.GetKey("s") || Input.GetKey("down"))
            {
                rb.velocity += new Vector2(0.0f, -vSpeed);
            }
        }
    }
}
