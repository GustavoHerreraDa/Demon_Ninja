using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaChain1 : MonoBehaviour
{
    private float chainSpeed = 6;
    private float chainDamage;
    private float chainStart;
    private float chainEnd;

    private Rigidbody2D chainRigidbody;

    private void Awake()
    {
        
    }

    void Start()
    {
        chainRigidbody = GetComponent<Rigidbody2D>();
        chainStart = transform.position.x;
        chainEnd = chainStart + 4;
    }
    
    void Update()
    {
        ChainMovement();
    }

    private void ChainMovement()
    {
        chainRigidbody.velocity = chainSpeed * new Vector2(1, 0);
        float position = transform.position.x;
        if (position > chainEnd)
        {
            Destroy(gameObject);
        }
    }
}
