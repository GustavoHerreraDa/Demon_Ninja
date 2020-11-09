﻿using System.Collections;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public Rigidbody2D myRigidbody;
    private float _moveSpeed = 2f;
    private bool canMove = false;


    void Awake()
    {
        MaxHealth = 30;
        CurrentHealth = MaxHealth;
        Damage = 10;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageFeedBack = GetComponent<ColorFeedback>();
        myRigidbody = GetComponent<Rigidbody2D>();
        playerToPersuit = FindObjectOfType<PlayerController>().gameObject;

        canMove = false;
        IsAlive = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        ChangeDirection();

        if (!isHurt && IsAlive && canMove)
            Move();

        if (!IsAlive)
        {
            //zombieCollider.enabled = false;

            //if (zombieDiesAudio != null)
            //    zombieSource.PlayOneShot(zombieDiesAudio);

            Death();
        }
    }

    void Move()
    {
        var auxPosition = Vector2.MoveTowards(transform.position, playerToPersuit.transform.position, _moveSpeed * Time.deltaTime);
        myRigidbody.MovePosition(auxPosition);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        canMove = true;

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.substractHealth(Damage);
                player.Hurt();
                StartCoroutine(WaitUntilPersuit());
            }
        }
    }

    public IEnumerator WaitUntilPersuit()
    {
        var gravityScalse = myRigidbody.gravityScale;
        myRigidbody.gravityScale = 0;
        //if (zombieCollider != null)
        //    zombieCollider.enabled = false;

        yield return new WaitForSeconds(0.5f);

        //if (zombieCollider != null)
        //    zombieCollider.enabled = true;

        myRigidbody.gravityScale = myRigidbody.gravityScale;

    }

    private void ChangeDirection()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerToPersuit.transform.position);
        Vector2 leftOrRight = playerToPersuit.transform.position - transform.position;

        Debug.Log("leftOrRight" + leftOrRight);

        if (leftOrRight.x > 0)
        {
            ChangeToLeft();
        }
        else if (leftOrRight.x < 0)
            ChangeToRight();
    }

    private void ChangeToLeft()
    {
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    private void ChangeToRight()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);

    }
}