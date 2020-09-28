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
            ninjaControl.isJumping = false;
            ninjaControl.jumpCounter = 0;
            //Debug.Log("is grounded");
        }
    }
}
