using UnityEngine;

public class RocketLeagueCarController : MonoBehaviour
{
    public float driveForce = 17f;
    public float turnSpeed = 3.5f;
    public float maxVelocity = 20f;
    public float boostMultiplier = 2.0f;
    public float rotationSpeed = 100f; // Speed of rotation for bumpers

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Read the input from the triggers
        float forwardTrigger = Input.GetAxis("ForwardTrigger");
        float reverseTrigger = Input.GetAxis("ReverseTrigger");

        // Determine movement direction
        float moveVertical = 0;
        if (forwardTrigger > 0.1f)
        {
            moveVertical = forwardTrigger; // Move forward
        }
        else if (reverseTrigger > 0.1f)
        {
            moveVertical = -reverseTrigger; // Move backward
        }

        // Apply the drive force with or without boost
        Vector3 forceToAdd;
        if (Input.GetButton("Boost"))
        {
            forceToAdd = transform.forward * moveVertical * driveForce * boostMultiplier;
        }
        else
        {
            forceToAdd = transform.forward * moveVertical * driveForce;
        }
        rb.AddForce(forceToAdd, ForceMode.Acceleration);

        // Handle turning with horizontal axis
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.angularVelocity = Vector3.up * moveHorizontal * turnSpeed;

        // Limit the velocity to the max velocity
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);

        // Handle bumper-based rotation
        if (Input.GetButton("RightBumper"))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotationSpeed * Time.fixedDeltaTime, 0f));
        }
        if (Input.GetButton("LeftBumper"))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, -rotationSpeed * Time.fixedDeltaTime, 0f));
        }
    }
}
