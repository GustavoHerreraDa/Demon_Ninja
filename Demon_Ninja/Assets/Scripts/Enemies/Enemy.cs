using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    public GameObject playerToPersuit;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    internal ColorFeedback damageFeedBack;
    internal int Damage;
    internal bool isHurt;

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
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public void BeingHurt()
    {
        if (damageFeedBack != null)
            damageFeedBack.StartFlash();

        StartCoroutine("BeingHurtCoRoutine");
    }

    private IEnumerator BeingHurtCoRoutine()
    {
        isHurt = true;
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
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
