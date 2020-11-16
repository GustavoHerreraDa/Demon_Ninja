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

    void JumpAttack();

    void BreathFire();
}

public class BerserkController : PlayerController
{
    public BerskerCombatStyle berserkCombatStyle;

    private Animator animator;
    private Vector2 tempMovement = Vector2.down;

    private IBerserkAttackStrategy berserkAttackStrategy;
    private BerserkAxeAndShield berserkAxeAndShield;
    private BerserkTwoAxe berserkTwoAxe;

    public int Damage;

    private PlayerAnimations animations;

    [Header("Fire")]
    public bool canFire;
    public int FireDamage;
    public GameObject prefabFireExit;
    public GameObject prefabFireBreath;
    public float fireCooldown;
    public BerserkUI fireCycle;

    public bool isVikingAttacking = false;

    

    public void Awake()
    {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;

        canDoubleJump = false;
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody2D>();
        playerSprite = this.GetComponent<SpriteRenderer>();
        audioSource = this.GetComponent<AudioSource>();
        Damage = 10;

        berserkTwoAxe = new BerserkTwoAxe(GetComponent<Animator>());
        berserkAxeAndShield = new BerserkAxeAndShield(GetComponent<Animator>());
        berserkAttackStrategy = berserkAxeAndShield;
        fireCycle = FindObjectOfType<BerserkUI>();

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
        if (Input.GetKeyDown(KeyCode.Z) && !isJumping)
        {
            StartCoroutine(BasicAttack());
            tempMovement = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.X) && !isJumping)
        {
            if (!canFire)
                return;

            StartCoroutine(BreathFire());
            tempMovement = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.Z) && isJumping)
        {
            StartCoroutine(JumpAttack());
            tempMovement = Vector2.zero;
        }



        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    StartCoroutine(HeavyAttack());
        //    tempMovement = Vector2.zero;
        //    HeavyAttack();
        //}
    }

    public IEnumerator BasicAttack()
    {
        isVikingAttacking = true;
        berserkAttackStrategy.BasicAttack();
        //GameObject berserkSlash = GameObject.Instantiate(prefabSlash, prefabExit.transform);

        //berserkSlash.GetComponent<BerserkSlash>().SetDamage(Damage);
        //berserkSlash.transform.position = prefabExit.transform.position;


        yield return new WaitForSeconds(0.3f);
        isVikingAttacking = false;
        if (attackAudio != null)
        {
            audioSource.clip = attackAudio;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }

    }

    public IEnumerator JumpAttack()
    {
        berserkAttackStrategy.JumpAttack();

        yield return new WaitForSeconds(0.3f);
        if (attackAudio != null)
        {
            audioSource.clip = attackAudio;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }

    public IEnumerator HeavyAttack()
    {
        berserkAttackStrategy.HeavyAttack();
        yield return new WaitForSeconds(0.3f);
    }

    public IEnumerator BreathFire()
    {
        canFire = false;
        berserkAttackStrategy.BreathFire();
        StarFireCicle();
        yield return new WaitForSeconds(0.4f);
        GameObject berserkFireBreath = GameObject.Instantiate(prefabFireBreath);
        var fireOrientation = prefabFireExit.transform.position - transform.position;

        berserkFireBreath.transform.position = prefabFireExit.transform.position;
        berserkFireBreath.GetComponent<FireBreath>().SetPosition(new Vector3(fireOrientation.x, 0));
        berserkFireBreath.GetComponent<FireBreath>().SetDamage(FireDamage);

        StartCoroutine(ShootCooldown());
    }

    private void StarFireCicle()
    {
        if (fireCycle is null)
            return;

        fireCycle.Fire();
    }

    private void CompleteFire()
    {
        if (fireCycle is null)
            return;

        fireCycle.CompletedFireCooldown();
    }

    IEnumerator ShootCooldown()
    {
        canFire = false;

        float ticks = 0;

        while (ticks < fireCooldown)
        {
            ticks += Time.deltaTime;
            yield return null;
        }
        CompleteFire();
        canFire = true;
    }

    public  void SetCircle(BerserkUI berserkUI)
    {
        this.fireCycle = berserkUI;
    }

}
