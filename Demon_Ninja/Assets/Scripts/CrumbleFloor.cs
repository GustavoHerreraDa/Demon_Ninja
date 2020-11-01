using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbleFloor : MonoBehaviour
{
    public Rigidbody2D rockRigid;
    public int x;
    
    public void PutGravity()
    {
        StartCoroutine(Gravity());
    }

    public IEnumerator Gravity()
    {
        // Segundo que vas a esperar
        yield return new WaitForSeconds(1);
        rockRigid.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Awake()
    {
        rockRigid.bodyType = RigidbodyType2D.Static;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PutGravity();
        }
    }
}
