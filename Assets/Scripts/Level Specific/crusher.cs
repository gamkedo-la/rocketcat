using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crusher : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Transform smasher;
    public float crushPhaseShift = 0.0f;
    public float rate = 1.0f;
    public float period = 1.0f;
    private float posPerc = 0.0f;
    private float delayBeforeCrush = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        delayBeforeCrush = rate * crushPhaseShift;
    }

    // Update is called once per frame
    void Update()
    {
        if(delayBeforeCrush > 0.0f)
        {
            delayBeforeCrush -= Time.deltaTime;
            return;
        }
        posPerc = (Mathf.Cos(Time.timeSinceLevelLoad/period) * 0.5f + 0.5f) * rate;
        posPerc = Mathf.Clamp01(posPerc);
        smasher.transform.position = posPerc * start.transform.position + (1.0f - posPerc) * end.transform.position;
        smasher.transform.rotation = Quaternion.Slerp(start.transform.rotation, end.transform.rotation, posPerc);
    }

}
