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
        Damage = 10;
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
            Debug.Log("player health" + player.CurrentHealth);

            if (player != null)
            {
                player.substractHealth(Damage);
                player.Hurt();
            }
        }
    }

    //private void Flip()
    //{
    //    _zombieSprite.flipX = !_zombieSprite.flipX;
    //}
}
