using UnityEngine;

public class RotateWithBumper : MonoBehaviour
{
    public float rotationSpeed = 90f; // Degrees per second
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check for right bumper input
        if (Input.GetButton("RightBumper"))
        {
            Debug.Log("Right bumper pressed - Rotating right");
            RotateObject(rotationSpeed);
        }

        // Check for left bumper input
        if (Input.GetButton("LeftBumper"))
        {
            Debug.Log("Left bumper pressed - Rotating left");
            RotateObject(-rotationSpeed);
        }
    }

    private void RotateObject(float speed)
    {
        if (rb != null && !rb.isKinematic)
        {
            // If Rigidbody is present and not kinematic, use MoveRotation for physics-based rotation
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, speed * Time.deltaTime, 0f));
        }
        else
        {
            // Otherwise, rotate the Transform directly
            transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.World);
        }
    }
}
