using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDeflect : MonoBehaviour
{


    public void DeflectShot(RocketMove rocket)
    {
        Rigidbody2D rb = rocket.GetRB();
        //rb.velocity = -rb.velocity;
        rocket.transform.Rotate(Vector3.forward, Random.Range(-10f, 10f) + 180.0f);
        Debug.Log("Attempted to deflect");
    }

}
