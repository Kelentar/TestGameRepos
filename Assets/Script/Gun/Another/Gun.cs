using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public float timeShot;
    public float startTime;

    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (timeShot <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, firePoint.position, transform.rotation);
                timeShot = startTime;

            }
        }
        else
        {
            timeShot -= Time.deltaTime;
        }
    } 
}