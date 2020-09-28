using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : PlayerController
{
    public float jumpCounter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        MidAirMovement();
        GroundMovement();
    }

    public override void MidAirMovement()
    {
        if (input.jumpPressed && !isJumping && jumpCounter< 2)
        {
            Debug.Log("1Jump");
            isRunning = false;
            jumpCounter = jumpCounter + 1;
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
