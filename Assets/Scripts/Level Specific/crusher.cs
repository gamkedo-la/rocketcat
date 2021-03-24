using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crusher : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Transform smasher;
    public float rate = 1.0f;
    public float period = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posPerc = 0.0f;
        posPerc = (Mathf.Cos(Time.timeSinceLevelLoad/period) * 0.5f + 0.5f) * rate;
        posPerc = Mathf.Clamp01(posPerc);
        smasher.transform.position = posPerc * start.transform.position + (1.0f - posPerc) * end.transform.position;
        smasher.transform.rotation = Quaternion.Slerp(start.transform.rotation, end.transform.rotation, posPerc);
    }

}
