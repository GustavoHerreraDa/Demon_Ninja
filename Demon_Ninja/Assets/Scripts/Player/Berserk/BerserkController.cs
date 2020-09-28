using System.Collections;
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

    public void Awake()
    {
        berserkTwoAxe = new BerserkTwoAxe(animator);
        berserkAxeAndShield = new BerserkAxeAndShield(animator);
        berserkAttackStrategy = berserkAxeAndShield;
    }

    public void ChangeCombatStyle()
    {
        if (berserkCombatStyle == BerskerCombatStyle.AxeAndShield)
        {
            this.berserkCombatStyle = BerskerCombatStyle.TwoAxes;
            return;
        }

        if (berserkCombatStyle == BerskerCombatStyle.TwoAxes)
        {
            this.berserkCombatStyle = BerskerCombatStyle.AxeAndShield;
            return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeCombatStyle();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(BasicAttack());
            tempMovement = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(HeavyAttack());
            tempMovement = Vector2.zero;
            HeavyAttack();
        }
    }

    public IEnumerator BasicAttack()
    {
        animator.SetBool("isAttacking", true);
        berserkAttackStrategy.BasicAttack();
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isAttacking", false);
    }

    public IEnumerator HeavyAttack()
    {
        animator.SetBool("isAttacking", true);
        berserkAttackStrategy.HeavyAttack();
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isAttacking", false);
    }

}
