using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossFinaleDamageFlash : MonoBehaviour
{
    public static EnemyBossFinaleDamageFlash instance;

    Material bossMat;
    [SerializeField] Material bossHurt;
    private float bossTimeSpentFlashing = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        bossMat = gameObject.GetComponent<Renderer>().material;
    }

    //called by Health script when RocketCat is harmed in the DealDamage function
    public void DamageFlash()
    {
        StartCoroutine(StartDamageFlash());
    }

    IEnumerator StartDamageFlash()
    {
        GetComponent<SkinnedMeshRenderer>().material = bossHurt;
        yield return new WaitForSeconds(bossTimeSpentFlashing);
        GetComponent<MeshRenderer>().material = bossMat;
    }
}
