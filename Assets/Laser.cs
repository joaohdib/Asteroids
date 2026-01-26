using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 10f;
    private Rigidbody2D rb;
    public float offset = 0.05f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.up * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (this == null) return;

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.x > (1 + offset) || viewportPos.y > (1 + offset) ||
            viewportPos.x < -offset || viewportPos.y < -offset)
        {
            Destroy(gameObject);
        }
    }
}
