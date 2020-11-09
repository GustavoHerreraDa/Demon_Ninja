﻿using UnityEngine;

public class ZombieEnemy : Enemy
{
    public Transform[] waypoints;

    private float _moveSpeed = 2f;

    public int _waypointIndex = 0;

    public AudioClip zombieAttackAudio;
    public AudioClip zombieDiesAudio;
    public AudioSource zombieSource;

    public Collider2D zombieColldier;

    void Awake()
    {
        MaxHealth = 30;
        CurrentHealth = MaxHealth;
        Damage = 10;
        animator = GetComponent<Animator>();
        transform.position = waypoints[_waypointIndex].transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageFeedBack = GetComponent<ColorFeedback>();
        
    }

    public override void Update()
    {
        Move();

        if (!IsAlive)
        {
            zombieColldier.enabled = false;
            zombieSource.PlayOneShot(zombieDiesAudio);
            Death();
        }
    }

    void Move()
    {
        if (!isHurt)
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[_waypointIndex].transform.position,
                _moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[_waypointIndex].transform.position)
        {
            _waypointIndex += 1;
            Flip();
        }

        if (_waypointIndex == waypoints.Length)
            _waypointIndex = 0;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.substractHealth(Damage);
                player.Hurt();
                if (zombieSource.isPlaying)
                {
                    zombieSource.Stop();
                    zombieSource.PlayOneShot(zombieAttackAudio);
                }
                else zombieSource.PlayOneShot(zombieAttackAudio);
                
            }
        }
    }

    //private void Flip()
    //{
    //    _zombieSprite.flipX = !_zombieSprite.flipX;
    //}
}
