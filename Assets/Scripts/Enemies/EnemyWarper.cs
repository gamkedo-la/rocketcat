using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarper : MonoBehaviour
{
    [Header ("Warp")]
    private float teleportDist = 6.0f;
    private float teleportDistRand = 2.5f; //+ or - so twice this distance
    private float meleeDist = 2.0f;
    private float verticalRand = 3.0f; //+ or - so twice this distance
    private float visionRange = 40.0f;
    private Vector3 scaleFacingRight;

    [Header("Sounds")]
    public AudioSource audioSource;
    [SerializeField] [Range(0, 1)] float alertSoundVol = 0.05f;


    [Header("Animations")]
    Animator animator;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        scaleFacingRight = Vector3.one;
        scaleFacingRight.x = -1.0f;
        StartCoroutine(TeleportWithDelay());
        animator = GetComponent<Animator>();
        animator.SetBool("isPlayerDead", false);
    }



    IEnumerator TeleportWithDelay()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.7f);
            Vector3 towards = (PlayerController.instance.transform.position - transform.position);
            float dist = towards.magnitude;
            if (dist < visionRange)
            {
                towards.Normalize();
                Vector3 destToTest;
                if (dist > teleportDist)
                {
                    destToTest = transform.position + towards * (teleportDist + teleportDistRand * Random.Range(-1f, 1f)) + Vector3.up * Random.Range(-verticalRand, verticalRand);
                }
                else
                {
                    float dirMult = (transform.position.x < PlayerController.instance.transform.position.x ? -1f : 1f);
                    destToTest = PlayerController.instance.transform.position + Vector3.right * meleeDist * dirMult
                        + Vector3.up * Random.Range(-verticalRand, verticalRand);
                }
                if (Physics2D.OverlapCircle(destToTest, 1.0f) == false)
                {
                    transform.position = destToTest;
                    if(transform.position.x > PlayerController.instance.transform.position.x)
                    {
                        transform.localScale = Vector3.one;
                    }
                    else
                    {
                        transform.localScale = scaleFacingRight;
                    }
                }
            }

        }
    }

    public void Alert()
    {
        if (PlayerController.instance == null)
        {
            animator.SetBool("isPlayerDead", true);
            return;
        }
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < 20.0f)
        {
            alertSoundVol = 0.65f;
            audioSource.PlayOneShot(audioSource.clip, alertSoundVol);
        }
        else
        {
            animator.SetBool("isLooking", false);
        }
    }




    public void Attack()
    {
        if (PlayerController.instance == null)
        {
            animator.SetBool("isPlayerDead", true);
            return;
        }
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < 5.0f)
        {
            //play attack sound
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }



    private void Update()
    {
        Alert();
        Attack();
    }


}
