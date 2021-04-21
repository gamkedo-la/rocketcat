using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageFlash : MonoBehaviour
{
    public static PlayerDamageFlash instance;

    Material playerMat;
    public GameObject rocketCatModelRight;
    public GameObject rocketCatModelLeft;
    [SerializeField] Material playerHurt;
    private float timeSpentFlashing = 0.5f;
    public bool invulnTime = false;

    private SkinnedMeshRenderer catRight;
    private SkinnedMeshRenderer catLeft;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        catRight = rocketCatModelRight.GetComponent<SkinnedMeshRenderer>();
        catLeft = rocketCatModelLeft.GetComponent<SkinnedMeshRenderer>();
        playerMat = rocketCatModelRight.GetComponent<Renderer>().material;
    }

    //called by Health script when RocketCat is harmed in the DealDamage function
    public void DamageFlash()
    {
        StartCoroutine(StartDamageFlash());
    }

    IEnumerator StartDamageFlash()
    {
        invulnTime = true;
        catLeft.material = playerHurt;
        catRight.material = playerHurt;
        yield return new WaitForSeconds(timeSpentFlashing);
        catLeft.material = playerMat;
        catRight.material = playerMat;
        //Flashing time is half invulnerability time- this makes a more generous time window while preserving 
        //the right flashing time window
        yield return new WaitForSeconds(timeSpentFlashing);
        invulnTime = false;
    }


}
