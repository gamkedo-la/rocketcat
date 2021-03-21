using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageFlash : MonoBehaviour
{
    public static PlayerDamageFlash instance;

    Material playerMat;
    public GameObject rocketCatModel;
    [SerializeField] Material playerHurt;
    public float timeSpentFlashing = 0.5f;
    public bool invulnTime = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerMat = gameObject.GetComponent<Renderer>().material;
    }

    //called by Health script when RocketCat is harmed in the DealDamage function
    public void DamageFlash()
    {
        StartCoroutine(StartDamageFlash());
    }

    IEnumerator StartDamageFlash()
    {
        invulnTime = true;
        GetComponent<MeshRenderer>().material = playerHurt;
        yield return new WaitForSeconds(timeSpentFlashing);
        GetComponent<MeshRenderer>().material = playerMat;
        //Flashing time is half invulnerability time- this makes a more generous time window while preserving 
        //the right flashing time window
        yield return new WaitForSeconds(timeSpentFlashing);
        invulnTime = false;
    }


}
