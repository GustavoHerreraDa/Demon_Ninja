using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float thrust;
    private SpriteRenderer spriteRenderer;
    private GameObject playerToPersuit;

    Vector2 vectorRight = new Vector2(0.5f, 0);
    Vector2 vectorLeft = new Vector2(-0.5f, 0);
    Vector2 vectorThrust;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerToPersuit = FindObjectOfType<PlayerController>().gameObject;
        damage = 10;

        float distanceToPlayer = Vector3.Distance(transform.position, playerToPersuit.transform.position);

        Vector2 isRight = playerToPersuit.transform.position - transform.position;
        vectorThrust = vectorRight;

        if (isRight.x < 0)
        {
            vectorThrust = vectorLeft;
            //spriteRenderer.flipX = true;

        }
        else if (isRight.x > 0)
        {
            vectorThrust = vectorRight;
        }

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(vectorThrust, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerController player = collider.gameObject.GetComponent<PlayerController>();
            player.substractHealth(damage);
            player.Hurt();
            Destroy(gameObject);
        }
    }

}
