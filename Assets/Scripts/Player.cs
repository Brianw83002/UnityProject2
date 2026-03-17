using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public GameObject PauseScreen;


    public Animator anim;

    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference Sprint;
    public InputActionReference Pause;

    private bool paused;

    public float speed = 5f;
    public float Sprintspeed = 10f;
    public float jumpForce = 7f;
    private int jumpCount;
    private int maxJumps = 2;
    public float airControl = 3f;   // <-- declared here
    Rigidbody2D rb;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        paused = false;
        PauseScreen.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPause();
        if (!paused)
        {
            CheckJump();
            CheckGrounded();

            if (Pause.action.IsPressed()) PauseGame();
        }
        
    
    }

    private void FixedUpdate()
    {
        if(!paused) Move();
    }

    //Using InputActionReference(Move), Move the character
    void Move()
    {
        Vector2 input = move.action.ReadValue<Vector2>();
        if (Sprint.action.IsPressed())
            speed = Sprintspeed;
        else
            speed = 5f;


        float targetX = input.x * speed;


        bool grounded = Mathf.Abs(rb.linearVelocity.y) < 0.01f;

        if (grounded)
        {
            rb.linearVelocity = new Vector2(targetX, rb.linearVelocity.y);
        }
        else
        {
            float newX = Mathf.Lerp(rb.linearVelocity.x, targetX, airControl * Time.fixedDeltaTime);
            rb.linearVelocity = new Vector2(newX, rb.linearVelocity.y);
        }

        anim.SetFloat("AnimSpeed", Mathf.Abs(rb.linearVelocity.x));
        
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


    public void PauseGame()
    {
        Debug.Log("Paused");
        PauseScreen.SetActive(true);
    }

    public void CheckPause()
    {
        if (PauseScreen.activeSelf)
        {
            Debug.Log("Game Is Paused");
            paused = true;
        }
        else paused = false;
    }

    private void CheckPauseButton()
    {
        if (Pause.action.triggered) PauseGame();
    }
    


}
