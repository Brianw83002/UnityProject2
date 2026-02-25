using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public InputActionReference move;
    public float speed = 5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 input = move.action.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, input.y, 0.0f);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

}
