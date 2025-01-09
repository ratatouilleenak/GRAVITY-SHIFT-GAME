using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;  // Movement speed
    [SerializeField] private LayerMask jumpableGround; // Ground layer for grounding checks
    [SerializeField] private Transform groundCheck; // Ground check position
    [SerializeField] private float checkRadius = 0.1f; // Ground check radius

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float moveInput;
    public bool facingRight = true; // Track facing direction
    private bool isGrounded; // Check if grounded

    private enum MovementState { idle, running, jumping, falling }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Handle horizontal movement
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the player based on direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // Update animations
        UpdateAnimationState();
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        if (groundCheck != null)
        {
            Vector2 direction = GroundCheckDirection();
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, jumpableGround);
        }
    }

    private Vector2 GroundCheckDirection()
    {
        return rb.gravityScale > 0 ? Vector2.down : Vector2.up;
    }

    void Flip()
    {
        facingRight = !facingRight;

        //transform.Rotate (0f, 180f,0);
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // Flip the X scale to change direction
        transform.localScale = scaler;
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        // Determine animation state
        if (Mathf.Abs(moveInput) > 0.1f) // Running state for significant movement
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        // Update animator
        if (anim != null)
        {
            anim.SetInteger("state", (int)state);
        }
    }

    private bool IsGrounded()
    {
        //Ground check using OverlapCircle for simple collision check
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, jumpableGround);
    }

    public bool canAttack()
    {
        return moveInput == 0 && isGrounded;
    }
}
