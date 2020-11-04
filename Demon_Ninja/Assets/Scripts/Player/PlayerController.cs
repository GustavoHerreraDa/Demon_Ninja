using System.Collections;
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
    public bool canDoubleJump;
    public bool isHurt;
    public bool jumpAttack;

    [Header("Environment Check Properties")]
    public float footOffset = .4f;
    public float groundDistance = .2f;
    public LayerMask groundLayer;

    public PlayerInput input;
    BoxCollider2D bodyCollider;
    public Rigidbody2D rigidBody;
    public SpriteRenderer playerSprite;
    public AudioSource audioSource;

    public AudioClip attackAudio;
    public AudioClip jumpAudio;
    public AudioClip hurtSound;
    public AudioClip deadSound;
    public AudioClip footStep;

    // Start is called before the first frame update
    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody2D>();
        playerSprite = this.GetComponent<SpriteRenderer>();
    }

    public virtual void FixedUpdate()
    {
        //PhysicsCheck();
        GroundMovement();
        MidAirMovement();
        FlipCharacterDirection();
        if (!isHurt)
        {
            ReturnColor();
        }

        if (!IsAlive)
        {
            Death();
        }
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


        FootSound();

    }

    public void FlipCharacterDirection()
    {
        /*direction *= -1;
        Vector3 scale = transform.localScale;
        transform.localScale = scale;*/
        if (rigidBody.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else
        {
            if (rigidBody.velocity.x < 0)
            {
                transform.localScale = new Vector2(-1, transform.localScale.y);
            }
        }
    }

    public virtual void MidAirMovement()
    {
        if (input.jumpPressed && !isJumping)
        {
            isRunning = false;
            isJumping = true;
            Jump();
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(jumpAudio);
            }
            else audioSource.PlayOneShot(jumpAudio);
        }
    }

    public void Jump()
    {
        rigidBody.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
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

    public void Hurt()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(hurtSound);
        }
        else audioSource.PlayOneShot(hurtSound);

        StartCoroutine(HurtRoutine());
    }

    public void Death()
    {
        Debug.Log("Muerte");
        if (audioSource.isPlaying && deadSound != null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(deadSound);
        }
        else audioSource.PlayOneShot(deadSound);
    }

    public void ReturnColor()
    {
        playerSprite.color = Color.Lerp(playerSprite.color, Color.white, Time.deltaTime / 1.5f);
    }
    public IEnumerator HurtRoutine()
    {
        isHurt = true;
        playerSprite.color = new Color(2, 0, 0);
        yield return new WaitForSeconds(0.3f);
        isHurt = false;
        Debug.Log(playerSprite.color);
    }

    public void FootSound()
    {
        if (isJumping)
            return;
        if (isRunning)
        {
            if (footStep != null)
            { audioSource.clip = footStep; audioSource.Play(); }
        }
    }
}
