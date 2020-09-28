using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : PlayerController
{
    public float jumpCounter = 0;
    private float ninjaCurrentHitpoints;
    private float ninjaMaxHitpoints = 100;
    void Start()
    {
        ninjaCurrentHitpoints = ninjaMaxHitpoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
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
    public IEnumerator DamageEntity(int damage, float interval)
    {
        while (true)
        {
            ninjaCurrentHitpoints = ninjaCurrentHitpoints - damage;
            if (ninjaCurrentHitpoints <= float.Epsilon)
            {
                KillCharacter();
                break;
            }
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    private void KillCharacter()
    {
        this.gameObject.SetActive(false);
    }
}
