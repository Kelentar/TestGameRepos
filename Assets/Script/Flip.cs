using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    
    //private bool m_FacingRight = true;
    //public float moveInput;

   
    
   
    

   

    //void FixedUpdate()
    //{
       
    //    moveInput = Input.GetAxis("Horizontal");
        

    //    if (m_FacingRight == false && moveInput > 0)
    //    {
    //        Facing();
            
    //    }
    //    else if (m_FacingRight == true && moveInput < 0)
    //    {
    //        Facing();
           
    //    }
    //}

    void Start()
    {
        
       
    }

    // Update is called once per frame
    private void Update()
    {

        

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







    void Facing()
    {
        //m_FacingRight = !m_FacingRight;

        //transform.Rotate(0f, 180f, 0f);

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }



    }
}
