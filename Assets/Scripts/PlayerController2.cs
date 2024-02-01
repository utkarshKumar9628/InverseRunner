using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    private Collider2D playerCollider;
    private Rigidbody2D rb;
    private bool isGrounded;
    public int maxJumps = 2;
    private int jumpsRemaining;
    private bool isPaused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || jumpsRemaining > 0)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        if (!isGrounded)
        {
            jumpsRemaining--;
        }

        // Apply an opposite force to make the player jump upside down
        rb.velocity = new Vector2(rb.velocity.x, 0); // Reset vertical velocity before jumping
        rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);

        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
        }
    }
    void OnBecameInvisible()
    {
        // Pause the game when the player is not visible by the camera
        Time.timeScale = 0f;
        isPaused = true;
        SceneManager.LoadScene(1);
    }

    void OnBecameVisible()
    {
        // Resume the game when the player is visible by the camera
        Time.timeScale = 1f;
        isPaused = false;
    }
}