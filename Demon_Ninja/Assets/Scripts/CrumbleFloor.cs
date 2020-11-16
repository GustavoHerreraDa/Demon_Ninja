using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbleFloor : MonoBehaviour
{
    public Rigidbody2D rockRigid;
    public int x;
    public GameObject floorSprite;

    private Animator animator;

    public AudioSource crumbleAudio;

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

        animator = GetComponentInChildren<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            crumbleAudio.Play();
            animator.SetTrigger("crumble");
            floorSprite.transform.position = floorSprite.transform.position + new Vector3(0, -0.2f, 0);
            PutGravity();
        }
    }
}
