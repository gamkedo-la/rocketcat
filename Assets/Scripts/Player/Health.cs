﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static Health instance;

    List<GameObject> healthIcons;
    private int health = 5;
    private float pushMultiplier = 250f;
    Rigidbody2D rb;

    /*Material playerMat;
    public GameObject rocketCatModel;
    [SerializeField] Material playerHurt;
     */

    private void Start()
    {
        instance = this;
        //playerMat = gameObject.GetComponent<Renderer>().material;

        rb = gameObject.GetComponent<Rigidbody2D>();
        healthIcons = new List<GameObject>();
        for (int i = 0; i < health; i++)
        {
            GameObject icon = GameObject.Find("Health " + (i + 1));
            healthIcons.Add(icon);
        }
        UpdateIcons();
    }

    private void UpdateIcons()
    {
        for (int i = 0; i < healthIcons.Count; i++)
        {
            healthIcons[i].SetActive(i < health);
        }
    }

    public bool DealDamage(bool invulOverride = false)
    {
        if (PlayerDamageFlash.instance.invulnTime && invulOverride == false)
        {
            return false;
        }
        health--;
        UpdateIcons();
        PlayerDamageFlash.instance.DamageFlash();
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.DelayThenLoadScene(false);
        }
        return true;
    }


    /*IEnumerator DamageFlash()
    {
        invulnTime = true;
        GetComponent<MeshRenderer>().material = playerHurt;
        yield return new WaitForSeconds(1.0f);
        GetComponent<MeshRenderer>().material = playerMat;
        invulnTime = false;
    }*/


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (DealDamage())
            {
                KnockBack();
            }

        }
    }


    public void ResetHealth()
    {
        health = 5;
        UpdateIcons();
    }

    private void KnockBack()
    {
        Vector3 pushFrom = transform.position + Vector3.up * -1.5f;
        rb.AddForce((rb.transform.position - pushFrom).normalized * pushMultiplier);
        //PlayerController pc = gameObject.GetComponent<PlayerController>();
    }

    public bool ToggleInvincible()
    {
        PlayerDamageFlash.instance.invulnTime = !PlayerDamageFlash.instance.invulnTime;
        return PlayerDamageFlash.instance.invulnTime;
    }
}
