﻿using UnityEngine;

public class Buullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;
    public float DestroyTime;






    void Start()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        rb.velocity = transform.right * speed;

        Invoke("DestroyAmmo", DestroyTime);
    }
    
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BossBehavior boss = hitInfo.GetComponent<BossBehavior>();
        Enemy_behavior enemy = hitInfo.GetComponent<Enemy_behavior>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }



}
