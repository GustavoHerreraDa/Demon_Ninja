using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : Health
{
    public GameObject deathEffect;

    public ColorFeedback damageFeedBack;
    public BoxCollider2D boxCollider2D;

    private AudioSource audioSource;
    private AudioClip audioDestroy;
    public virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public virtual void DeathEffect()
    {
        if (deathEffect != null)
        {
            var effect = Instantiate(deathEffect, this.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    public void Hurt()
    {
        StartCoroutine(DisableCollider());

        if (damageFeedBack != null) {
            damageFeedBack.StartFlash();
        }
    }

    public IEnumerator DisableCollider()
    {
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(0.3f);
        boxCollider2D.enabled = true;
    }

    public void PlaySound()
    {
        if (audioDestroy != null)
        { audioSource.clip = audioDestroy; audioSource.Play(); }
    }
}
