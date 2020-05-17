using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_behavior : MonoBehaviour
{
    #region Public Variables;
    public int health;
    public int currentHealth;
   


    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    
    #endregion

    #region Private Variable
    private Animator anim;
    private float distance;
    public bool attackMode;
    private bool cooling;
    private float intTimer;
    #endregion


    void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
        
        currentHealth = health;
        
    }
    // Update is called once per frame
    void Update()
    {
        

        if (!attackMode)
        {
            Move();
        }

        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            SelectTarget();
        }

       
        

        
        if (inRange)
        {
            EnemyLogic();
            
        }

        
    }

    

        void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
            if(distance > attackDistance)
        {
            
            StopAttack();
        }
            else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("Run", true);
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        
        anim.SetBool("Run", false);
        anim.SetBool("Attack", true);

    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }
    

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        
            float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
            float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

            if (distanceToLeft > distanceToRight)
            {
                target = leftLimit;
            }
            else
            {
                target = rightLimit;
            }

            Flip();
            
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }



    public void TakeDamage(int damage)
    {


        currentHealth -= damage;

        anim.SetTrigger("HitEnemy");

        if(currentHealth <= (health / 2) )
        {
            moveSpeed *= 2;
            timer /= 2;
            anim = GetComponent<Animator>();
            anim.speed = 1.5f;
        }

        if (currentHealth <= 0)
        {
            
            Die();
        }
        
    }

    public void Die()
    {
        Debug.Log("Enemy die");
        anim.SetBool("DeadEnemy", true);

        hotZone.GetComponent<HotZoneCheck>().isDead = true;

        
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }
}
