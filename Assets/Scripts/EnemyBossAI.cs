using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossAI : MonoBehaviour
{
    [Header("Warp")]
    private float teleportDist = 6.0f;
    private float teleportDistRand = 2.5f; //+ or - so twice this distance
    private float meleeDist = 2.0f;
    private float verticalRand = 3.0f; //+ or - so twice this distance
    private float visionRange = 40.0f;
    private Vector3 scaleFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveSlowly());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoveSlowly()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
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
                    if (transform.position.x > PlayerController.instance.transform.position.x)
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
}
