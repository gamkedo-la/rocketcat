using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InconsistentLight : MonoBehaviour
{

    Light myLight;
    public float darkIntensity = 0.1f;
    public float lightIntensity = 1.2f;
    private float minDark = 2.5f;
    private float maxDark = 4f;
    private float minLight = 1.6f;
    private float maxLight = 2.4f;


    // Start is called before the first frame update
    void Start()
    {
        myLight = gameObject.GetComponent<Light>();
        StartCoroutine(LightChange());
    }



    IEnumerator LightChange()
    {
        while(true)
        {
            myLight.intensity = darkIntensity;
            yield return new WaitForSeconds(Random.Range(minDark, maxDark));
            myLight.intensity = lightIntensity;
            yield return new WaitForSeconds(Random.Range(minLight, maxLight));
        }
    }


}
