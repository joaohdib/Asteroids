using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Asteroid : MonoBehaviour
{
    public GameObject subAsteroidPrefab;
    public int numberOfSubAsteroids = 2;

    public enum Size { Small, Medium, Large };
    public Size asteroidSize;

    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    private Rigidbody2D rb;

    public int scoreToAdd = 30;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 randomDirection = Random.insideUnitCircle.normalized; // random 360 degrees direction
        float speed = Random.Range(minSpeed, maxSpeed);
        rb.linearVelocity = randomDirection * speed;
        rb.AddTorque(Random.Range(-20f, 20f));
    }

    public void Die()
    {
        if (subAsteroidPrefab != null)
        {
            for (int i = 0; i < numberOfSubAsteroids; i++)
            {
                Instantiate(subAsteroidPrefab, transform.position, Quaternion.identity);
            }
        }
        GameManager.Instance.AddScore(scoreToAdd);
        Destroy(gameObject);
    }
}
