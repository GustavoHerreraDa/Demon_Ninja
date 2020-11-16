using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    public PlatformEffector2D _effector;

    public float waitTime;
    void Start()
    {
        _effector = GetComponent<PlatformEffector2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            waitTime = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _effector.rotationalOffset = 180f;
                waitTime = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _effector.rotationalOffset = 0f;
        }
    }
}
