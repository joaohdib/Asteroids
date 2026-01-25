using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;

    void Awake()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (mainCamera == null) return;
        Wrap();
    }

    private void Wrap()
    {
        // Convert current world position to viewport coordinates (0 to 1)
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);
        bool outOfBounds = false;

        // Margin to ensure the object is fully off-screen before wrapping
        float margin = 0.08f;

        // Check Horizontal boundaries
        if (viewportPos.x > 1 + margin) 
        { 
            viewportPos.x = -margin; 
            outOfBounds = true; 
        }
        else if (viewportPos.x < -margin) 
        { 
            viewportPos.x = 1 + margin; 
            outOfBounds = true; 
        }

        // Check Vertical boundaries
        if (viewportPos.y > 1 + margin) 
        { 
            viewportPos.y = -margin; 
            outOfBounds = true; 
        }
        else if (viewportPos.y < -margin) 
        { 
            viewportPos.y = 1 + margin; 
            outOfBounds = true; 
        }

        // If out of bounds, apply the new position to the Rigidbody
        if (outOfBounds)
        {
            // Maintain the correct distance from camera for the conversion
            float zDistance = Mathf.Abs(mainCamera.transform.position.z - transform.position.z);
            viewportPos.z = zDistance;

            Vector3 newWorldPos = mainCamera.ViewportToWorldPoint(viewportPos);

            if (rb != null)
            {
                // Teleport using the physics position to avoid interpolation jitter
                rb.position = new Vector2(newWorldPos.x, newWorldPos.y);
            }
            else
            {
                // Fallback for objects without physics
                newWorldPos.z = transform.position.z;
                transform.position = newWorldPos;
            }
        }
    }
}