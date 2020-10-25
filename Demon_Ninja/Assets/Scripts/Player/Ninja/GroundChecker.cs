using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public NinjaController ninjaControl;
    

     public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ninjaControl.isGrounded = true;
        }
    }

     public void OnCollisionExit2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Ground"))
         {
             ninjaControl.isGrounded = false;
         }
     }
}
