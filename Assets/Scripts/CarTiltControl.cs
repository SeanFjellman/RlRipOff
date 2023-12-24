using UnityEngine;

public class CarTiltControl : MonoBehaviour
{
    public float tiltAmount = 30f; // Maximum tilt angle
    public float tiltSpeed = 2f; // Speed of tilting
    public float deadZone = 0.1f; // Dead zone for the joystick

    private Rigidbody rb;
    private float lastTilt = 0f; // Last tilt angle

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            Debug.LogError("Rigidbody component missing!");
        }
    }

    void Update()
    {
        // Get the vertical input from the left joystick
        float verticalInput = Input.GetAxis("Vertical");

        // Update the lastTilt only if there is significant input
        if (Mathf.Abs(verticalInput) > deadZone)
        {
            lastTilt = verticalInput * tiltAmount;
        }

        // Current rotation around the X axis
        float currentTilt = transform.eulerAngles.x;

        // Normalize the angle to -180 to 180 to prevent excessive rotation
        if (currentTilt > 180)
        {
            currentTilt -= 360;
        }

        // Interpolate smoothly towards the last tilt
        currentTilt = Mathf.Lerp(currentTilt, lastTilt, Time.deltaTime * tiltSpeed);

        // Apply the rotation
        transform.rotation = Quaternion.Euler(currentTilt, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
