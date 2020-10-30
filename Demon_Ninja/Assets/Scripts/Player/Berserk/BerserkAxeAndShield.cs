using UnityEngine;

public class BerserkAxeAndShield : IBerserkAttackStrategy
{
    private Animator animator;
    public BerserkAxeAndShield(Animator animator)
    {
        this.animator = animator;
    }
    public void BasicAttack()
    {
        animator.SetTrigger("BasicAttack");
    }

    public void JumpAttack()
    {
        animator.SetTrigger("JumpAttack");
    }

    public void HeavyAttack()
    {
        animator.SetTrigger("HeavyAttack");
    }

    public void BreathFire()
    {
        animator.SetTrigger("BreathFire");
    }
}
