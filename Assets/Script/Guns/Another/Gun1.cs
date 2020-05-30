using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour
{
    public Transform firePoint1;
    public Rigidbody2D bullet1;
    public Animator animator;

    public float timeShot1;
    public float startTime1;

    public float timeUpShot1;
    public float startUpTime1;

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

        if (timeShot1 <= 0)
        {
            if (Input.GetButtonDown("Fire1") && !animator.GetCurrentAnimatorStateInfo(0).IsName("IsJumping"))
            {

                animator.SetTrigger("Attack2");
                timeShot1 = startTime1;

            }

        }
        else
        {

            timeShot1 -= Time.deltaTime;
        }
        if (timeUpShot1 > startUpTime1)
        {

            Rigidbody2D clone = Instantiate(bullet1, firePoint1.position, transform.rotation) as Rigidbody2D;
            timeUpShot1 = 0;
        }
        if (timeShot1 >= 0.5)
        {
            timeUpShot1 += Time.deltaTime;
        }

    }
}