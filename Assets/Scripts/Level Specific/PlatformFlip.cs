using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFlip : MonoBehaviour
{
    public float percPhaseShift = 0.0f;
    public float flipWait = 2.0f;
    public float flipSpeed = 100.0f;
    private float flipAng = 0.0f;
    private float delayBeforeNextFlip = 0.0f;
    private float nextAngLock = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        delayBeforeNextFlip = flipWait * percPhaseShift;
    }

    // Update is called once per frame
    void Update()
    {
        if(delayBeforeNextFlip > 0.0f)
        {
            delayBeforeNextFlip -= Time.deltaTime;
            return;
        }
        flipAng += flipSpeed * Time.deltaTime;

        if(flipAng >= nextAngLock)
        {
            flipAng = nextAngLock;
            nextAngLock += 180.0f;
            delayBeforeNextFlip = flipWait;
        }
        transform.rotation = Quaternion.AngleAxis(flipAng, Vector3.forward);
    }
}
