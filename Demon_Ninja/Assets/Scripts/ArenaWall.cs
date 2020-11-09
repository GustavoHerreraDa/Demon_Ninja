using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaWall : MonoBehaviour
{
    public BerserkController vikingObject;

    public GameObject brokenWall;
    
  
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("FindPlayer");
            vikingObject = other.GetComponent<BerserkController>();
            if (vikingObject.isVikingAttacking)
            {
                Debug.Log("BreakWall");
                brokenWall.SetActive(true);
            }
        }
    }
}
