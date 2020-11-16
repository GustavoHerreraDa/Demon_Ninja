using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenWall : Enemy
{
    private Collider2D thisCollider;
    public GameObject showGameObject;
    private Rigidbody2D thisRigid;
    
    void Start()
    {
        MaxHealth = 20;
        CurrentHealth = MaxHealth;
        thisCollider = GetComponent<BoxCollider2D>();
        thisRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(MaxHealth);
    }
    
}
