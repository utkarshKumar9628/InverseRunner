using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpsRemaining; // Track the number of jumps allowed
    public int maxJumps = 2; // Set the maximum number of jumps
    private bool isPaused = false;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        jumpsRemaining = maxJumps; // Initialize the number of jumps
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = IsGrounded();

        // Player movement
       // float horizontalInput = Input.GetAxis("Horizontal");
      //  rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Player jump only when grounded or has jumps remaining and space is pressed
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded || jumpsRemaining > 0)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsRemaining--;

        // Reset jumps if grounded
        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
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