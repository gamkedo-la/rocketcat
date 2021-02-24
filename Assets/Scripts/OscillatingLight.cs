using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingLight : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(45.0f * Mathf.Cos(Time.timeSinceLevelLoad * 0.5f), Vector3.forward) * 
            Quaternion.AngleAxis(90.0f, Vector3.right); 
    }
}
