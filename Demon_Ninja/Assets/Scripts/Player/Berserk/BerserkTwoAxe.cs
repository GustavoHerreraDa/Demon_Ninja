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
        
    }

    public void HeavyAttack()
    {
    }
}
