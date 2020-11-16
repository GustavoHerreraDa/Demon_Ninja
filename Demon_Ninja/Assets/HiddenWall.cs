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
        MaxHealth = 30;
        CurrentHealth = 30;
        thisCollider = GetComponent<BoxCollider2D>();
        thisRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive)
        {
            thisCollider.enabled = false;
            showGameObject.SetActive(false);
        }
    }
    
}
