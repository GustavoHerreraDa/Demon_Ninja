using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : PlayerController
{
    public bool isGrounded;
    public bool canDoubleJump = false;
    public Animator ninjaAnimator;
    public void Awake()
    {
    }
    void Start()
    {
        
    }

    public virtual void FixedUpdate()
    {
        MidAirMovement();
        GroundMovement();
        FlipCharacterDirection();
    }
    void Update()
    {
        SetAnimations();
    }
    public override void MidAirMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            if (isGrounded)
            {
                Debug.Log("wants to jump");
                Debug.Log(rigidBody.velocity);
                rigidBody.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x , 0);
                    rigidBody.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);

                }
            }
        }
    }

    public void SetAnimations()
    {
        ninjaAnimator.SetFloat("Speed",Mathf.Abs(rigidBody.velocity.x));
        if (!isGrounded)
        {
            ninjaAnimator.SetBool("isJumping", true);
        }
        else
        {
            ninjaAnimator.SetBool("isJumping", false);
        }
    }
}
