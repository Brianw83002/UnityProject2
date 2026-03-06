using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = ((Vector2)target.position - rb.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Base"))
        {
            Destroy(gameObject);
        }
    }

}
