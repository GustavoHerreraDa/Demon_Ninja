using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAttackTrigger : MonoBehaviour
{
    private bool isAttacking = false;

    private float attackTimer = 0;
    private float meleeAttackColdown = 0.3f;
    private float chainAttackColdown = 1;
    private int meleeDamage = 20;

    public GameObject ninjaChain1;
    public GameObject ninjaChain2;
    
    public Collider2D attackTrigger;

    public NinjaController ninjaController;
    
    public Coroutine damageCoroutine;

    public Animator ninjaAnimators;
    public void Awake()
    {
        attackTrigger.enabled = false;
    }
    private void FixedUpdate()
    {
        PressTheAttack();
        CheckIfCanAttack();
    }
    public void PressTheAttack()
    {
        if (Input.GetKeyDown("j") && attackTimer < 0.1f)
        {
            isAttacking = true;
            attackTimer = meleeAttackColdown;
            attackTrigger.enabled = true;
            ninjaAnimators.SetTrigger("Attack");
        }
        if (Input.GetKeyDown("h") && attackTimer < 0.1f)
        {
            isAttacking = true;
            attackTimer = chainAttackColdown;
            ChainAttack();
            ninjaAnimators.SetTrigger("Throw");
        }
    }
    private void CheckIfCanAttack()
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

    private void ChainAttack()
    {
        float scale = ninjaController.transform.localScale.x;
        Debug.Log(scale);
        if (transform.localScale.x > 0)
        {
            GameObject ninjaChain = GameObject.Instantiate((ninjaChain1));
            ninjaChain.transform.position = ninjaController.transform.position + new Vector3(1,-1,0);
            ninjaChain.transform.up = ninjaController.transform.up;
            ninjaChain.transform.localScale = ninjaController.transform.localScale;

        }

        if (transform.localScale.x < 0)
        {
            GameObject ninjaChain = GameObject.Instantiate((ninjaChain2));
            ninjaChain.transform.position = ninjaController.transform.position + new Vector3(-1, -1,0);;
            ninjaChain.transform.up = ninjaController.transform.up;
            ninjaChain.transform.localScale = ninjaController.transform.localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ZombieEnemy enemyScript = collision.gameObject.GetComponent<ZombieEnemy>();
            enemyScript.GetDamage(meleeDamage);
        }
    }
}