using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("Ground") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Speed"))
        {
            anim = GetComponent<Animator>();
            anim.SetBool("IsJumping", false);
            anim.Play("Idle");
        }
    }
}
