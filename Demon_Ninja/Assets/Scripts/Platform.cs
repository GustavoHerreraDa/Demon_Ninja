using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform[] waypoints;

    private float _moveSpeed = 2f;

    private int _waypointIndex = 0;



    void Awake()
    {
        transform.position = waypoints[_waypointIndex].transform.position;
    }

    public void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypoints != null)
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[_waypointIndex].transform.position,
                _moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[_waypointIndex].transform.position)
        {
            _waypointIndex += 1;
        }

        if (_waypointIndex == waypoints.Length)
            _waypointIndex = 0;
    }
}
