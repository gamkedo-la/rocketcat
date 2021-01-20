using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EdgeArrows : MonoBehaviour
{
    public Image up;
    public Image down;
    public static Transform pointAt = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void TurnOffAll()
    {
        up.enabled = down.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pointAt == null)
        {
            TurnOffAll();
            return;
        }
        up.enabled = Camera.main.transform.position.y < pointAt.position.y;
        down.enabled = Camera.main.transform.position.y > pointAt.position.y;
    }
}
