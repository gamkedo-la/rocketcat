using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarper : MonoBehaviour
{
    private float teleportDist = 6.0f;
    private float meleeDist = 2.0f;

    IEnumerator TeleportWithDelay()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.7f);
            Vector3 towards = (PlayerController.instance.transform.position - transform.position);
            float dist = towards.magnitude;
            towards.Normalize();
            if (dist > teleportDist)
            {
                transform.position += towards * teleportDist;
            }
            else
            {
                float dirMult = (transform.position.x < PlayerController.instance.transform.position.x ? -1f : 1f);
                transform.position = PlayerController.instance.transform.position + Vector3.right * meleeDist * dirMult
                    + Vector3.up * Random.Range(-2.0f, 2.0f);
            }


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TeleportWithDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
