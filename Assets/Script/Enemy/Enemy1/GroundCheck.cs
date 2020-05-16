using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float checkRadius;
    private bool isGrounded;
    public float moveInput;

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
    }
}
