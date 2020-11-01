﻿using UnityEngine;

public class NinjaController : PlayerController
{
    public bool isGrounded;
    public Animator ninjaAnimator;
    public GameObject ninjaDoubleJump;
    public void Awake()
    {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        canDoubleJump = true;
        ninjaAnimator = GetComponent<Animator>();
        IsAlive = true;
        ninjaDoubleJump.gameObject.SetActive(false);
    }

    void Start()
    {
    }

    //public override void FixedUpdate()
    //{
    //    MidAirMovement();
    //    GroundMovement();
    //    FlipCharacterDirection();
    //}

    public override void Update()
    {
        base.Update();
        //SetAnimations();
        DoubleJumpAnim();
    }

    public void DoubleJumpAnim()
    {
        if (isJumping && canDoubleJump)
        {
            ninjaDoubleJump.gameObject.SetActive(true);
        }
        else ninjaDoubleJump.gameObject.SetActive(false);
    }
    public override void MidAirMovement()
    {
        if (input.jumpPressed && !isJumping)
        {
            isRunning = false;
            isJumping = true;
            Jump();
            return;
        }

        if (input.jumpPressed && isJumping && canDoubleJump)
        {
            canDoubleJump = false;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            Jump();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isJumping = false;
        canDoubleJump = true;
    }

    //public void SetAnimations()
    //{
    //    ninjaAnimator.SetFloat("Speed",Mathf.Abs(rigidBody.velocity.x));
    //    if (!isGrounded)
    //    {
    //        ninjaAnimator.SetBool("isJumping", true);
    //    }
    //    else
    //    {
    //        ninjaAnimator.SetBool("isJumping", false);
    //    }
    //}
}
