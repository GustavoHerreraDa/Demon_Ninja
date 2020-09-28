using System.Collections;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Coroutine damageCoroutine;

    private int enemyPatrolDamage = 5;
    public float speed;

    private float patrolMaxHitpoins = 30;
    public float patrolCurrentHitpoints;

    public Rigidbody2D enemyRigidbody;


    public int scoreGive = 50;


    private RaycastHit2D hit;

    private bool canPersuit;
    private GameObject player;
    private bool moveRight;

    public void Start()
    {
        speed = 1;
        patrolCurrentHitpoints = patrolMaxHitpoins;
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        Persuit();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NinjaController ninjaScript = collision.gameObject.GetComponent<NinjaController>();
            if (damageCoroutine == null)
            {
                Debug.Log(patrolCurrentHitpoints);
                damageCoroutine = StartCoroutine(ninjaScript.DamageEntity(enemyPatrolDamage, 0));
            }
        }
    }

    public IEnumerator DamageEntity(int damage, float interval)
    {
        while (true)
        {
            patrolCurrentHitpoints = patrolCurrentHitpoints - damage;
            if (patrolCurrentHitpoints <= float.Epsilon)
            {
                KillCharacter();
                break;
            }
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    public void KillCharacter()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {

            player = collider.gameObject;
            canPersuit = true;
        }
    }
    void Persuit()
    {
        if (canPersuit)
        {
            var auxPosition = transform.position - player.transform.position;


            if (auxPosition.normalized.x < 0)
                moveRight = true;
            else
                moveRight = false;

            if (moveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            }
        }
    }


}
