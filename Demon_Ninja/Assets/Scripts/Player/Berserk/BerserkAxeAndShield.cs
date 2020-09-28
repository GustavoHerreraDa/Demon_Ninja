using System.Collections;
using System.Collections.Generic;
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

    }

    public void HeavyAttack()
    {
    }
}
