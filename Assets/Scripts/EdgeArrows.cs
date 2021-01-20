using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EdgeArrows : MonoBehaviour
{
    public Image up;
    public Image down;
    public Image left;
    public Image right;
    public static Transform pointAt = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void TurnOffAll()
    {
        up.enabled = down.enabled = left.enabled = right.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pointAt == null)
        {
            TurnOffAll();
            return;
        }
        Vector2 screenPos = Camera.main.WorldToScreenPoint(pointAt.position);
        down.enabled = screenPos.y < 0;
        up.enabled = screenPos.y > Screen.height;
        left.enabled = screenPos.x < 0;
        right.enabled = screenPos.x > Screen.width;

    }
}
