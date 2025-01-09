using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMovement player;

    public Transform firePoint;
    public Transform groundCheck;

    private bool top = false; // Tracks if gravity is inverted

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlipGravity();
        }
    }

    void FlipGravity()
    {
        // Invert the gravity scale
        rb.gravityScale *= -1;

        // Reset velocity to stop unintended movement
        rb.velocity = Vector2.zero;

        // Flip the player's Y scale visually
        Vector3 newScale = transform.localScale;
        newScale.y *= -1;
        transform.localScale = newScale;

        // Adjust groundCheck position to align with gravity
        if (groundCheck != null)
        {
            Vector3 groundCheckPosition = groundCheck.localPosition;
            groundCheckPosition.y *= -1; // Flip the groundCheck vertically
            groundCheck.localPosition = groundCheckPosition;
        }

        // Rotate firePoint separately to match orientation
        if (firePoint != null)
        {
            Vector3 firePointScale = firePoint.localScale;
            firePointScale.y *= -1;
            firePoint.localScale = firePointScale;
        }

        SoundManager.instance.PlaySound(jumpSound);

        top = !top;
    }
}
