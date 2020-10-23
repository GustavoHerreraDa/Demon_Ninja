using UnityEngine;

public class ZombieEnemy : Enemy
{
    public Transform[] waypoints;

    private float _moveSpeed = 2f;

    private int _waypointIndex = 0;

    void Awake()
    {
        MaxHealth = 30;
        CurrentHealth = MaxHealth;
        animator = GetComponent<Animator>();
        transform.position = waypoints[_waypointIndex].transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        Move();

        if (!IsAlive)
            Death();
    }

    void Move()
    {
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

    //private void Flip()
    //{
    //    _zombieSprite.flipX = !_zombieSprite.flipX;
    //}
}
