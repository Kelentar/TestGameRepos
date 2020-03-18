using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Wapon : MonoBehaviour
{

    public bool hold;
    public float distance = 2f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwob = 5;
   
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!hold)
            {
                Physics2D.queriesStartInColliders = false;
                if (Input.GetAxis("Horizontal") < 0)
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance);
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                }


                if (hit.collider != null && hit.collider.tag == "Weapon")
                {
                    hold = true;
                }
            }
            else
            {
                hold = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)

                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 2) * throwob;

            }
        }

        if (hold)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;

            if(holdPoint.position.x > transform.position.x && hold == true)
            {
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * 1f, transform.localScale.y * 1f);
            }else if (holdPoint.position.x < transform.position.x && hold == true)
            {
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y * 1f);
            }
        }

    }
    private void OnDrawGizmo()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * transform.localScale.x * distance);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);

    }
   
}