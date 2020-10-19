using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : PlayerController
{
    public float jumpCounter = 0;
    private float ninjaCurrentHitpoints;
    private float ninjaMaxHitpoints = 100;
    public Animator ninjaAnimator;
    void Start()
    {
        ninjaCurrentHitpoints = ninjaMaxHitpoints;
    }

    // Update is called once per frame
    void Update()
    {
        ninjaAnimator.SetBool("isJumping", isJumping);
        ninjaAnimator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
    }
    public override void FixedUpdate()
    {
        MidAirMovement();
        GroundMovement();
        FlipCharacterDirection();
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
    

    private void KillCharacter()
    {
        this.gameObject.SetActive(false);
    }
}
