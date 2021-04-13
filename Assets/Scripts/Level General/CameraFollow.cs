using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;

    public bool introEnabled = false;
    public Transform introTransform;
    public float introDuration = 5f;
    public float introCameraFOV = 45f;
    private float introFinalCameraFOV = 90f;
    private float startTime = 0f;
    private float originalFOV = 90f;
    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        if (introEnabled) {
            cam = GetComponent<Camera>();
            originalFOV = cam.fieldOfView ;
            startTime = Time.time;
            Debug.Log("Camera Intro started at "+startTime);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform whoToLookAt = followTransform;
        cam.fieldOfView  = originalFOV;

        if (introEnabled && introTransform!=null) {
            if (Time.time - startTime < introDuration) {
                whoToLookAt = introTransform;
                cam.fieldOfView  = introCameraFOV;
            }
        }
        
        if (whoToLookAt != null)
        {
            this.transform.position = new Vector3(whoToLookAt.position.x, whoToLookAt.position.y, this.transform.position.z);
        }
    }
}
