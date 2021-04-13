using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageFadeOut : MonoBehaviour
{
    public int delayFrames = 120;
    public float fadeSpeed = 0.01f;
    private Image img;
    private Color rgba;
    private int frameCounter = 0;
    
    void Start()
    {
        img = GetComponent<Image>();
        rgba = img.color;
    }

    void Update()
    {
        frameCounter++;
        if (frameCounter>delayFrames && rgba.a > 0f) {
            rgba = img.color;
            rgba.a -= fadeSpeed;
            if (rgba.a<0f)rgba.a=0f;
            img.color = rgba;
        }
    }
}
