using UnityEngine;

public class BerserkTwoAxe : IBerserkAttackStrategy
{
    private Animator animator;
    public BerserkTwoAxe(Animator animator)
    {
        this.animator = animator;
    }


    public void BasicAttack()
    {
        this.animator.SetInteger("AttackStyle", (int)BerskerCombatStyle.TwoAxes);
        animator.SetTrigger("BasicAttack");
    }

    public void HeavyAttack()
    {
        this.animator.SetInteger("AttackStyle", (int)BerskerCombatStyle.TwoAxes);
        animator.SetTrigger("HeavyAttack");
    }
}
