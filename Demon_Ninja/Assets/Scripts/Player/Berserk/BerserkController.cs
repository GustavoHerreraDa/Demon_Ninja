﻿using System.Collections;
using UnityEngine;

public enum BerskerCombatStyle
{
    TwoAxes,
    AxeAndShield
}

public interface IBerserkAttackStrategy
{
    void BasicAttack();

    void HeavyAttack();
}

public class BerserkController : PlayerController
{
    public BerskerCombatStyle berserkCombatStyle;

    private Animator animator;
    private Vector2 tempMovement = Vector2.down;

    private IBerserkAttackStrategy berserkAttackStrategy;
    private BerserkAxeAndShield berserkAxeAndShield;
    private BerserkTwoAxe berserkTwoAxe;

    private PlayerAnimations animations;


    public void Awake()
    {
        berserkTwoAxe = new BerserkTwoAxe(GetComponent<Animator>());
        berserkAxeAndShield = new BerserkAxeAndShield(GetComponent<Animator>());
        berserkAttackStrategy = berserkAxeAndShield;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void ChangeCombatStyle()
    {
        if (berserkCombatStyle == BerskerCombatStyle.AxeAndShield)
        {
            this.berserkCombatStyle = BerskerCombatStyle.AxeAndShield;
            berserkAttackStrategy = berserkAxeAndShield;
            return;
        }

        if (berserkCombatStyle == BerskerCombatStyle.TwoAxes)
        {
            this.berserkCombatStyle = BerskerCombatStyle.AxeAndShield;
            berserkAttackStrategy = berserkTwoAxe;
            return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCombatStyle();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(BasicAttack());
            tempMovement = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(HeavyAttack());
            tempMovement = Vector2.zero;
            HeavyAttack();
        }
    }

    public IEnumerator BasicAttack()
    {
        berserkAttackStrategy.BasicAttack();
        yield return new WaitForSeconds(0.3f);
    }

    public IEnumerator HeavyAttack()
    {
        berserkAttackStrategy.HeavyAttack();
        yield return new WaitForSeconds(0.3f);
    }

}
