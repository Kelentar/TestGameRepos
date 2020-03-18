using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysicks1 : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;
    public float DestroyTime;

    

   


    void Start()
    {


        rb.velocity = transform.right * speed;
        Invoke("DestroyAmmo", DestroyTime);
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {


        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    void DestroyAmmo()
    {
        Destroy(gameObject);
    }



}
