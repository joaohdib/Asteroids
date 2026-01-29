using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Asteroid : MonoBehaviour
{
    [Header("Explosion Settings")]
    [SerializeField] private float explosionScale = 1f;
    [SerializeField] private GameObject explosionPrefab;

    public GameObject subAsteroidPrefab;

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
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Asteroid explosion sprite
        explosion.transform.localScale = Vector3.one * explosionScale;

        SoundManager.Instance.PlaySound("Explosion");

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        if (subAsteroidPrefab != null)
        {
            CreateSmallerAsteroids();
        }


        GameManager.Instance.AddScore(scoreToAdd);
        Destroy(gameObject);
    }

    private void CreateSmallerAsteroids()
    {
        for (int i = 0; i < 2; i++)
        {
            float offsetValue;

            if (i == 0)
            {
                offsetValue = -0.5f;
            }

            else
            {
                offsetValue = 0.5f;
            }

            Vector3 spawnPos = transform.position;
            spawnPos.x += offsetValue;
            spawnPos.y += offsetValue;

            GameObject small = Instantiate(subAsteroidPrefab, spawnPos, Quaternion.identity);

            Rigidbody2D rbSmall = small.GetComponent<Rigidbody2D>();
            rbSmall.linearVelocity = new Vector2(offsetValue * 2f, offsetValue * 2f);

        }
    }

}
