using UnityEngine;

public class RocketLeagueCarController : MonoBehaviour
{
    public float driveForce = 17f;
    public float turnSpeed = 3.5f;
    public float maxVelocity = 20f;
    public float boostMultiplier = 2.0f;
    public float rotationSpeed = 100f; // Speed of rotation for bumpers

    public float airRollSpeed = 50f; // Speed of rotation in the air

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        // Assuming that the ground has a specific tag
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Handle drive and turning
        HandleDrive();
        HandleTurning();

        // Handle air rolling
        if (!isGrounded)
        {
            HandleAirRoll();
        }

        // Limit the velocity
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void HandleDrive()
    {
        float forwardTrigger = Input.GetAxis("ForwardTrigger");
        float reverseTrigger = Input.GetAxis("ReverseTrigger");
        float moveVertical = 0;

        if (forwardTrigger > 0.1f)
        {
            moveVertical = forwardTrigger;
        }
        else if (reverseTrigger > 0.1f)
        {
            moveVertical = -reverseTrigger;
        }

        if (Input.GetKey("w"))
        {
            moveVertical = maxVelocity;
        }
        else if (Input.GetKey("s"))
        {
            moveVertical = -maxVelocity;
        }

        Vector3 forceToAdd;
        if (Input.GetButton("Boost") || Input.GetMouseButton(0))
        {
            forceToAdd = transform.forward * moveVertical * driveForce * boostMultiplier;
        }
        else
        {
            forceToAdd = transform.forward * moveVertical * driveForce;
        }
        rb.AddForce(forceToAdd, ForceMode.Acceleration);
    }

    private void HandleTurning()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.angularVelocity = Vector3.up * moveHorizontal * turnSpeed;
    }

    private void HandleAirRoll()
    {
        float roll = Input.GetAxis("Roll"); // Assumes "Roll" is mapped to an axis
        float pitch = Input.GetAxis("Pitch"); // Assumes "Pitch" is mapped to an axis
        float yaw = Input.GetAxis("Yaw"); // Assumes "Yaw" is mapped to an axis

        Vector3 airRotation = new Vector3(pitch, yaw, roll) * airRollSpeed * Time.fixedDeltaTime;
        rb.AddRelativeTorque(airRotation, ForceMode.Acceleration);
    }
}
