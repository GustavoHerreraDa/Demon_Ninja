﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    PlayerController movement;    
    Rigidbody2D rigidBody;
    PlayerInput input;          
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<PlayerController>();
        rigidBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("isRunning " + movement.isRunning);
        Debug.Log("isJumping " + movement.isJumping);

        anim.SetBool("isRunning", movement.isRunning);
        anim.SetBool("isJumping", movement.isJumping);
    }
}
