using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public Rigidbody2D bullet;
    public Animator animator;
    
    public float timeShot;
    public float startTime;

    public float timeUpShot;
    public float startUpTime;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (timeShot <= 0)
        {
            if (Input.GetButtonDown("Fire1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("IsJumping"))
            {

                animator.SetTrigger("Attack1");
                timeShot = startTime;
                
            }
            
        }
        else
        {
            
            timeShot -= Time.deltaTime;
        }
        if (timeUpShot > startUpTime)
        {

            Rigidbody2D clone = Instantiate(bullet, firePoint.position, transform.rotation) as Rigidbody2D;
            timeUpShot = 0;
        }
        if (timeShot >= 1)
        {
            timeUpShot += Time.deltaTime;
        }

    }
}