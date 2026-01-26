using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 randomDirection = Random.insideUnitCircle.normalized; // random 360 degrees direction

        float speed = Random.Range(minSpeed,maxSpeed);

        rb.linearVelocity = randomDirection * speed;

        rb.AddTorque(Random.Range(-20f,20f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
