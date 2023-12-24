using UnityEngine;

public class CarRotationControl : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotation speed

    void Update()
    {
        // Check for left bumper press
        if (Input.GetButton("LeftBumper"))
        {
            // Rotate to the left
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
        }

        // Check for right bumper press
        if (Input.GetButton("RightBumper"))
        {
            // Rotate to the right
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
    }
}
