using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    public GameObject playerToPersuit;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    internal int Damage;

    public void Walk()
    {
        animator.SetBool("isWalking", true);
    }

    public void StopWalk()
    {
        animator.SetBool("isWalking", false);
    }

    public void Death()
    {
        StartCoroutine("DeathCoRoutine");
    }

    private IEnumerator DeathCoRoutine()
    {
        animator.SetTrigger("IsDeath");
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

    public void BeingHurt()
    {
        StartCoroutine("BeingHurtCoRoutine");
    }

    private IEnumerator BeingHurtCoRoutine()
    {
        yield return new WaitForSeconds(1.5f);
    }

    protected void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    //public virtual void HurtSound()
    //{
    //    if (audioSource != null)
    //    {
    //        audioSource.clip = audioClipHurt;
    //        audioSource.Play();
    //    }
    //}

}
