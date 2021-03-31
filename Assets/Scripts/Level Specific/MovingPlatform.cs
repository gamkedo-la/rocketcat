using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool isVertical = false;
    public float distance = 7.0f;
    public float periodForHowLongLoop = 1.0f;
    public float phaseShift = 0.0f;

    public float swayDistance = 0.0f;
    public float swayTime = 1.0f;
    public float swayShift = 0.0f;

    private Vector3 startPos;
    private Vector3 offsetVec;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        UpdateVector();
    }

    void UpdateVector()
    {
        if (isVertical)
        {
            offsetVec = Vector3.up;
        }
        else
        {
            offsetVec = Vector3.right;
        }
    }



    // Update is called once per frame
    void Update()
    {
        float phaseNow = 0.5f + 0.75f * Mathf.Cos(phaseShift + Time.timeSinceLevelLoad / periodForHowLongLoop); //0.75 is bigger than 0.5 so it stops on the ends
        phaseNow = Mathf.Clamp01(phaseNow);
        if (swayDistance > 0.0f)
        {
            float swayPhase = Mathf.Cos(swayShift + Time.timeSinceLevelLoad / swayTime);
            float swayAng = swayPhase * 30.0f;
            transform.rotation = Quaternion.AngleAxis(swayAng, Vector3.forward);
            transform.position = startPos + offsetVec * phaseNow * distance + swayPhase * Vector3.right * swayDistance;
        }
        else
        {
            transform.position = startPos + offsetVec * phaseNow * distance;
        }
    }

    public void OnDrawGizmos()
    {
        UpdateVector();
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + offsetVec * distance);
    }


}
