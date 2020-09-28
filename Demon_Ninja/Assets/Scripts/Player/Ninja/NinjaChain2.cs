using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaChain2 : MonoBehaviour
{
    private float chainSpeed = -6;
    private int chainDamage = 15;
    private float chainStart;
    private float chainEnd;

    private Rigidbody2D chainRigidbody;
    
    public Coroutine damageCoroutine;

    private void Awake()
    {
        
    }

    void Start()
    {
        chainRigidbody = GetComponent<Rigidbody2D>();
        chainStart = transform.position.x;
        chainEnd = chainStart - 4;
    }
    
    void Update()
    {
        ChainMovement();
    }

    private void ChainMovement()
    {
        chainRigidbody.velocity = chainSpeed * new Vector2(1, 0);
        float position = transform.position.x;
        if (position < chainEnd)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PatrolEnemy patrolScript = collision.gameObject.GetComponent<PatrolEnemy>();
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(patrolScript.DamageEntity(chainDamage, 0));
            }
        }
    }
}
