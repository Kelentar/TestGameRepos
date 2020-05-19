using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public HeroScript controller;
    public Animator animator;
    public Gun gun1;
    public Gun1 gun2;
    //public GameObject clone;

    //public GameObject bullet;

    public float runSpeed = 70f;

    

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    void Start()
    {
        gun1 = GetComponent<Gun>();
        gun2 = GetComponent<Gun1>();
    }
    // Update is called once per frame
    
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            
            
            runSpeed = 0f;
        }
        else
        {
            runSpeed = 20f;
        }
        

    }

    public void Attack1()
    {
        //clone.GetComponent<Gun>().Shoot();
        gun1.Shoot();
    }
    public void Attack2()
    {
        
        gun2.Shoot();

    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    
}
