using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldmaiden : MonoBehaviour
{
    public Transform shield;
    private Vector3 relativeShieldPos;
    private bool flipped = false;

    // Start is called before the first frame update
    void Start()
    {
        relativeShieldPos = shield.position - transform.position;
        StartCoroutine(ShieldFlip());
    }

    
    IEnumerator ShieldFlip()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.0f);
            flipped = !flipped;
            shield.position = transform.position + relativeShieldPos * (flipped ? -1.0f : 1.0f);
        }
    }


}
