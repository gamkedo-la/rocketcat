using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject gruntLaserProjectile;
    [SerializeField] Transform laserFrom;
    [SerializeField] float speed = 1f;

    void Update()
    {
        //GameObject.Instantiate(gruntLaserProjectile, laserFrom.position, laserFrom.rotation, null);
        gruntLaserProjectile.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        health.DealDamage();
    }

}
