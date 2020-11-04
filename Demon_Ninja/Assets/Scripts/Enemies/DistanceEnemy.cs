using UnityEngine;

public class DistanceEnemy : Enemy
{
    public GameObject prefabProyectile;

    public float maxDistanceAttack;
    public Transform shootExit;
    public float shootTime;
    public float currentShootTime;
    private bool canShoot;
    private bool startShoot;
    [SerializeField] private float distanceTrigger;

    void Start()
    {
        CurrentHealth = 30;
        MaxHealth = 30;
        IsAlive = true;
        maxDistanceAttack = 5;
        shootTime = 3;
        animator = GetComponentInChildren<Animator>();
        playerToPersuit = FindObjectOfType<PlayerController>().gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        startShoot = false;
        damageFeedBack = GetComponent<ColorFeedback>();
    }

    public override void Update()
    {
        base.Update();

        float distanceToPlayer = Vector2.Distance(transform.position, playerToPersuit.transform.position);
        Debug.Log("Distance " + distanceToPlayer);
        Vector2 leftOrRight = playerToPersuit.transform.position - transform.position;

        

        if (leftOrRight.x > 0)
        {
            ChangeToRight();

        }
        else if (leftOrRight.x < 0)
            ChangeToLeft();

        if (distanceToPlayer < distanceTrigger)
        {
            startShoot = true;
        }

        if (!startShoot)
            return;

        if (canShoot)
        {
            DistanceAttack();
            canShoot = false;
        }
        else
        {
            currentShootTime += Time.deltaTime;
            if (currentShootTime >= shootTime)
            {
                canShoot = true;
                currentShootTime = 0;
            }
        }

        if (!IsAlive)
        {
            Death();
        }
    }

    private void ChangeToLeft()
    {
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    private void ChangeToRight()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);

    }

    public void DistanceAttack()
    {
        animator.SetTrigger("Attack");
        Vector3 shotDirection = shootExit.position + shootExit.forward;//target.position - shootExit.position;
        GameObject.Instantiate(prefabProyectile, shootExit.position, Quaternion.LookRotation(transform.forward));
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceTrigger);
    }

    //public override void HurtSound()
    //{
    //    base.HurtSound();
    //}


}
