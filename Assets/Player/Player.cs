using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public InputActionReference move;
    public float speed = 5f;
    Rigidbody2D rb;

    private float Xbound = -6.0f;
    private float Ybound = -4.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Xbound = 6.0f;
        Ybound = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    //Using InputActionReference(Move), Move the character
    void Move()
    {
        // Get WASD input
        Vector2 input = move.action.ReadValue<Vector2>();
        Vector2 movement = input.normalized * speed; // normalize for diagonal speed

        // Calculate new position
        Vector2 newPos = rb.position + movement * Time.fixedDeltaTime;

        // Clamp to bounds
        newPos.x = Mathf.Clamp(newPos.x, -Xbound, Xbound);
        newPos.y = Mathf.Clamp(newPos.y, -Ybound, Ybound);

        // Move Rigidbody using MovePosition (physics-safe)
        rb.MovePosition(newPos);

    }

}
