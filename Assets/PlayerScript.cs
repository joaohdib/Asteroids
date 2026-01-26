using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [Header("Movement Settings")]
    public float thrustSpeed = 5f;
    public float rotationSpeed = 180f;

    private Rigidbody2D rb;
    private float rotationInput;
    private bool isThrusting;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 0.25f;
    private float nextFireTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isThrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
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
    }

}
