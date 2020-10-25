using UnityEngine;

public class PlayerController : Health
{
    public bool drawDebugRaycasts = true;

    [Header("Movement Properties")]
    public float speed = 8f;

    [Header("Jump Properties")]
    public float jumpForce = 6.3f;

    [Header("Status Flags")]
    public bool isJumping;
    public bool isRunning;
    public bool isAttacking;

    [Header("Environment Check Properties")]
    public float footOffset = .4f;
    public float groundDistance = .2f;
    public LayerMask groundLayer;

    public PlayerInput input;
    BoxCollider2D bodyCollider;
    public Rigidbody2D rigidBody;

    int direction = 1;

    // Start is called before the first frame update
    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void FixedUpdate()
    {
        //PhysicsCheck();
        GroundMovement();
       // MidAirMovement();
        FlipCharacterDirection();
    }
    public virtual void GroundMovement()
    {
        float xVelocity = speed * input.horizontal;

        if (input.horizontal != 0)
            isRunning = true;
        else
        {
            isRunning = false;
            xVelocity = 0;
        }

        /*if (xVelocity * direction < 0f)
            FlipCharacterDirection();*/

        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);

    }

    public void FlipCharacterDirection()
    {
        /*direction *= -1;
        Vector3 scale = transform.localScale;
        transform.localScale = scale;*/
        if (rigidBody.velocity.x > 0)
        {
           transform.localScale =  new Vector2( 1,transform.localScale.y);
        }
        else
        {
            if (rigidBody.velocity.x < 0)
            {
                transform.localScale =  new Vector2(-1, transform.localScale.y);
            }
        }
    }

    public virtual void MidAirMovement()
    {
        if (input.jumpPressed && !isJumping)
        {
            isRunning = false;
            isJumping = true;
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    void PhysicsCheck()
    {
        isJumping = false;

        RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, 0f), Vector2.down, groundDistance);
        RaycastHit2D rightCheck = Raycast(new Vector2(footOffset, 0f), Vector2.down, groundDistance);

        if (leftCheck || rightCheck)
            isJumping = true;
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length)
    {
        return Raycast(offset, rayDirection, length, groundLayer);
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask)
    {
        Vector2 pos = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

        if (drawDebugRaycasts)
        {
            Color color = hit ? Color.red : Color.green;
            Debug.DrawRay(pos + offset, rayDirection * length, color);
        }

        return hit;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isJumping = false;
        //Debug.Log("OnCollisionEnter2D");
    }

}
