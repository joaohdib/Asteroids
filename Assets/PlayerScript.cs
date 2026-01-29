using NUnit.Framework;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float thrustSpeed = 5f;
    public float rotationSpeed = 180f;

    [SerializeField] private float explosionScale = 1f;
    [SerializeField] private GameObject explosionPrefab;

    private Rigidbody2D rb;
    private float rotationInput;
    private bool isThrusting;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 0.25f;
    private float nextFireTime = 0f;

    public int health = 5;

    public HealthUI healthUI;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isThrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0)
        {
            animator.SetBool("Flying", true);
        }
        else
        {
            animator.SetBool("Flying", false);
        }

        rotationInput = Input.GetAxis("Horizontal"); // A/D or Left/Right

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate; // delay between shots
        }
    }

    void FixedUpdate()
    {
        HandleThrust();
        HandleRotation();
    }


    private void HandleThrust()
    {
        if (isThrusting)
        {
            // Apply force in the direction the ship is facing
            rb.AddForce(transform.up * thrustSpeed);
        }
    }

    private void HandleRotation()
    {
        // Apply torque for rotation
        float rotation = -rotationInput * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation + rotation);
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        SoundManager.Instance.PlaySound("Laser");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            TakeDamage();
        }
    }

    private void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.localScale = Vector3.one * explosionScale;
        SoundManager.Instance.PlaySound("ShipExplosion");

        Invoke("GameOver", 0.3f); // Callin GameOver function after 0.3 seconds delay
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }

    private void TakeDamage()
    {
        health--;
        healthUI.UpdateHealthDisplay(health);
        SoundManager.Instance.PlaySound("Hit");
        if (health < 1)
        {
            Die();
        }
    }

    public void RestartPlayer()
    {
        health = 5;

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        transform.position = Vector3.zero; // Position zero to the player

        healthUI.UpdateHealthDisplay(5);
        
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        
    }

}
