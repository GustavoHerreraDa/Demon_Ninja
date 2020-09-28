using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Coroutine damageCoroutine;

    private int enemyPatrolDamage = 5;

    private float patrolMaxHitpoins = 30;
    public float patrolCurrentHitpoints;
    
    public Rigidbody2D enemyRigidbody;
    
    public void Start()
    {
        patrolCurrentHitpoints = patrolMaxHitpoins;
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NinjaController ninjaScript = collision.gameObject.GetComponent<NinjaController>();
            if (damageCoroutine == null)
            {
                Debug.Log(patrolCurrentHitpoints);
                damageCoroutine = StartCoroutine(ninjaScript.DamageEntity(enemyPatrolDamage, 0));
            }
        }
    }
    public IEnumerator DamageEntity(int damage, float interval)
    {
        while (true)
        {
            patrolCurrentHitpoints = patrolCurrentHitpoints - damage;
            if (patrolCurrentHitpoints <= float.Epsilon)
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

    public void KillCharacter()
    {
        this.gameObject.SetActive(false);
    }

    
}
