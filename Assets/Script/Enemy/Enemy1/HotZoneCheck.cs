using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private Enemy_behavior enemyParent;
    private bool inRange;
    private Animator anim;

    public bool isDead;
    

    private void Awake()
    {
        enemyParent = GetComponentInParent<Enemy_behavior>();
        anim = GetComponentInParent<Animator>();

    }


    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack") && !isDead)
        {
            
            enemyParent.Flip();
        }
            
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
        }
    }

   
}
