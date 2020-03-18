﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce;
    private bool m_FacingRight = true;
    public float moveInput;

    public Rigidbody2D rb;
    public Animator anim;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public int currentAmmo = 20;
    public int allAmmo = 0;
    public int fullAmmo = 45;

    [SerializeField]
    private Text ammoCount;


    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
   
    // Update is called once per frame
    private void Update()
    {
        
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {

            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("jump");
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {

            rb.velocity = Vector2.up * jumpForce;

        }


        //if (Input.GetAxis("Horizontal") == 0)
        //{
        //    anim.SetInteger("operator", 1);
        //}
        //else
        //{
        //    Flip();
        //    anim.SetInteger("operator", 2);
        //}


       
            
        
        
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (m_FacingRight == false && moveInput > 0)
        {
            Flip();
            anim.SetInteger("operator", 1);
        }
        else if (m_FacingRight == true && moveInput < 0)
        {
            Flip();
            anim.SetInteger("operator", 2);
        }

        ammoCount.text = currentAmmo + "/" + allAmmo;
    }




    void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);

        //if (Input.GetAxis("Horizontal") < 0)
        //{
        //    transform.localRotation = Quaternion.Euler(0, 180, 0);
        //}
        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //    transform.localRotation = Quaternion.Euler(0, 0, 0);
        //}



    }
    
}


//using UnityEngine;
//using UnityEngine.Events;

//public class HeroScript : MonoBehaviour
//{
//    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
//    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
//    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
//    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
//    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
//    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
//    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
//    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

//    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
//    private bool m_Grounded;            // Whether or not the player is grounded.
//    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
//    private Rigidbody2D m_Rigidbody2D;
//    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
//    private Vector3 m_Velocity = Vector3.zero;

//    [Header("Events")]
//    [Space]

//    public UnityEvent OnLandEvent;

//    [System.Serializable]
//    public class BoolEvent : UnityEvent<bool> { }

//    public BoolEvent OnCrouchEvent;
//    private bool m_wasCrouching = false;

//    private void Awake()
//    {
//        m_Rigidbody2D = GetComponent<Rigidbody2D>();

//        if (OnLandEvent == null)
//            OnLandEvent = new UnityEvent();

//        if (OnCrouchEvent == null)
//            OnCrouchEvent = new BoolEvent();
//    }

//    private void FixedUpdate()
//    {
//        bool wasGrounded = m_Grounded;
//        m_Grounded = false;

//        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
//        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
//        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
//        for (int i = 0; i < colliders.Length; i++)
//        {
//            if (colliders[i].gameObject != gameObject)
//            {
//                m_Grounded = true;
//                if (!wasGrounded)
//                    OnLandEvent.Invoke();
//            }
//        }
//    }


//    public void Move(float move, bool crouch, bool jump)
//    {
//        // If crouching, check to see if the character can stand up
//        if (!crouch)
//        {
//            // If the character has a ceiling preventing them from standing up, keep them crouching
//            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
//            {
//                crouch = true;
//            }
//        }

//        //only control the player if grounded or airControl is turned on
//        if (m_Grounded || m_AirControl)
//        {

//            // If crouching
//            if (crouch)
//            {
//                if (!m_wasCrouching)
//                {
//                    m_wasCrouching = true;
//                    OnCrouchEvent.Invoke(true);
//                }

//                // Reduce the speed by the crouchSpeed multiplier
//                move *= m_CrouchSpeed;

//                // Disable one of the colliders when crouching
//                if (m_CrouchDisableCollider != null)
//                    m_CrouchDisableCollider.enabled = false;
//            }
//            else
//            {
//                // Enable the collider when not crouching
//                if (m_CrouchDisableCollider != null)
//                    m_CrouchDisableCollider.enabled = true;

//                if (m_wasCrouching)
//                {
//                    m_wasCrouching = false;
//                    OnCrouchEvent.Invoke(false);
//                }
//            }

//            // Move the character by finding the target velocity
//            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
//            // And then smoothing it out and applying it to the character
//            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

//            // If the input is moving the player right and the player is facing left...
//            if (move > 0 && !m_FacingRight)
//            {
//                // ... flip the player.
//                Flip();
//            }
//            // Otherwise if the input is moving the player left and the player is facing right...
//            else if (move < 0 && m_FacingRight)
//            {
//                // ... flip the player.
//                Flip();
//            }
//        }
//        // If the player should jump...
//        if (m_Grounded && jump)
//        {
//            // Add a vertical force to the player.
//            m_Grounded = false;
//            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
//        }
//    }


//    private void Flip()
//    {
//        // Switch the way the player is labelled as facing.
//        m_FacingRight = !m_FacingRight;

//        transform.Rotate(0f, 180f, 0f);
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HeroScript : MonoBehaviour
//{

//    public CharacterController controller;
//    public Animator animator;

//    public float runSpeed = 40f;

//    float horizontalMove = 0f;
//    bool jump = false;
//    bool crouch = false;

//    // Update is called once per frame
//    void Update()
//    {

//        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

//        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

//        if (Input.GetButtonDown("Jump"))
//        {
//            jump = true;
//            animator.SetBool("IsJumping", true);
//        }

//        if (Input.GetButtonDown("Crouch"))
//        {
//            crouch = true;
//        }
//        else if (Input.GetButtonUp("Crouch"))
//        {
//            crouch = false;
//        }

//    }

//    public void OnLanding()
//    {
//        animator.SetBool("IsJumping", false);
//    }

//    public void OnCrouching(bool isCrouching)
//    {
//        animator.SetBool("IsCrouching", isCrouching);
//    }

//    void FixedUpdate()
//    {
//        // Move our character
//        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
//        jump = false;
//    }
//}