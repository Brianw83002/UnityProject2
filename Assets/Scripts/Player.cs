using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference jump;
    
    public float speed = 5f;
    public float jumpForce = 7f;
    private int jumpCount;
    private int maxJumps = 2;
    public float airControl = 3f;   // <-- declared here
    Rigidbody2D rb;

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        CheckJump();
        CheckGrounded();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //Using InputActionReference(Move), Move the character
    void Move()
    {
        Vector2 input = move.action.ReadValue<Vector2>();
        float targetX = input.x * speed;

        // Check if grounded
        bool grounded = Mathf.Abs(rb.linearVelocity.y) < 0.01f;

        if (grounded)
        {
            // Full control on ground
            rb.linearVelocity = new Vector2(targetX, rb.linearVelocity.y);
        }
        else
        {
            // Air control: smoother movement in air
            float newX = Mathf.Lerp(rb.linearVelocity.x, targetX, airControl * Time.fixedDeltaTime);
            rb.linearVelocity = new Vector2(newX, rb.linearVelocity.y);
        }
    }


    // Jumping
    void CheckJump()
    {
        if (jump.action.triggered && jumpCount > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount--;
            //Debug.Log("JumpCount: " + jumpCount);
        }
    }

    void CheckGrounded()
    {
        // If player horizontal velocity is zero, assume grounded
        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            jumpCount = maxJumps;  // reset jumps
            //Debug.Log("JumpCount: " + jumpCount);
        }
    }


}
