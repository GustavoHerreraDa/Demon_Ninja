using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAttackTrigger : MonoBehaviour
{
    private bool isAttacking = false;

    private float attackTimer = 0;
    private float attackColdown = 0.3f;

    public Collider2D attackTrigger;

    public void Awake()
    {
        attackTrigger.enabled = false;
    }
    private void FixedUpdate()
    {
        pressTheAttack();
        checkIfCanAttack();
    }
    public void pressTheAttack()
    {
        if (Input.GetKeyDown("j") && attackTimer < 0.5f)
        {
            isAttacking = true;
            attackTimer = attackColdown;
            attackTrigger.enabled = true;
        }
    }
    public void checkIfCanAttack()
    {
        if (isAttacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}
