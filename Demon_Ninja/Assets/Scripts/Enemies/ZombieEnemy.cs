using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    public Transform[] waypoints;
    
    private float _moveSpeed = 2f;

    private int _waypointIndex = 0;

    private SpriteRenderer _zombieSprite;

    public int currentLife;
    public int maxLife = 30;

    void Start () {
        transform.position = waypoints [_waypointIndex].transform.position;
        _zombieSprite = GetComponent<SpriteRenderer>();
        currentLife = maxLife;
    }

    void Update () {
        Move ();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards (transform.position,
            waypoints[_waypointIndex].transform.position,
            _moveSpeed * Time.deltaTime);

        if (transform.position == waypoints [_waypointIndex].transform.position) {
            _waypointIndex += 1;
            Flip();
        }
				
        if (_waypointIndex == waypoints.Length)
            _waypointIndex = 0;
    }

    private void Flip()
    {
        _zombieSprite.flipX = !_zombieSprite.flipX;
    }

    public void GetDamage(int damage)
    {
        currentLife = currentLife - damage;
        if (currentLife < 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
