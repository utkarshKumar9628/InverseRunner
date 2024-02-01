using UnityEngine;

public class DualPlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpsRemaining; // Track the number of jumps allowed
    public int maxJumps = 2; // Set the maximum number of jumps

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

        // Player movement (mirrored)
        

        // Player jump only when grounded and space is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Check if there are remaining jumps
        if (jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;
        }

        // Optionally, reset jumps even when not grounded to allow mid-air jumps
        // Remove this part if you want to allow jumps only when grounded
        if (!isGrounded && jumpsRemaining == 0)
        {
            jumpsRemaining = maxJumps;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}