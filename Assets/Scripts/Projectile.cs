using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed;

    private Vector2 target;

    // change this if player's height is modified (used to have projectiles shoot at chest level)
    private float offsetHeight = 0.5f;

    private void Start()
    {
        target = new Vector2(PlayerController.instance.transform.position.x, (PlayerController.instance.transform.position.y + offsetHeight));
        transform.LookAt(target);
    }


    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        // This makes projectiles stop at the player's last known position, which gives the appearance of a projectile
        // "dying out". This can always be commented back in if this is what's desired :thumbs_up:
        // transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        // if(transform.position.x == target.x && transform.position.y == target.y)
        // {
        //     DestroyProjectile();
        // }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health.instance.DealDamage();
            DestroyProjectile();
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            DestroyProjectile();
        }
    }

}
