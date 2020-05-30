using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public HeroScript controller;
    public Animator animator;
    public Rigidbody2D rb;
    

    public float runSpeed;

    

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            rb.GetComponent<Rigidbody2D>().gravityScale = 3f;
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

    
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        rb.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
