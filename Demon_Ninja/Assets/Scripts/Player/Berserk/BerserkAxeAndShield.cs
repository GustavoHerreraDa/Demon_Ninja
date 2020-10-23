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

    public void HeavyAttack()
    {
        Debug.Log("BerskerCombatStyle.AxeAndShield " + (int)BerskerCombatStyle.AxeAndShield);
        this.animator.SetInteger("AttackStyle", (int)BerskerCombatStyle.AxeAndShield);
        animator.SetTrigger("HeavyAttack");
    }
}
