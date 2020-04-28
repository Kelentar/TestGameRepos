using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startTimeBtwShots;
    public float timeBtwShots;

    public GameObject projectile;

    public float speed;
    public float stopingdistance;
    public float retreatDistance;
    public int health = 100;

    public Transform player;
    public GameObject deathEffect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
         if(Vector2.Distance(transform.position, player.position) > stopingdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
         else if(Vector2.Distance(transform.position, player.position) < stopingdistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
            {
            transform.position = this.transform.position;
        }
         else if (Vector2.Distance(transform.position, player.position) < stopingdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

         if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
         else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}