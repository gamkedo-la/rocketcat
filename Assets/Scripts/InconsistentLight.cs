using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InconsistentLight : MonoBehaviour
{

    Light myLight;
    public float darkIntensity = 0.1f;
    public float lightIntensity = 1.2f;

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
            yield return new WaitForSeconds(Random.Range(3f, 5f));
            myLight.intensity = lightIntensity;
            yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
        }
    }


}
