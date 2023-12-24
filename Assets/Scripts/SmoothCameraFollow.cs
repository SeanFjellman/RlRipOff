using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform pivotTransform; // Reference to the pivot's transform
    public Vector3 offset; // Offset distance between the pivot and the camera
    public bool lookAtTarget = true; // Should the camera look at the pivot

    void LateUpdate()
    {
        // Update the camera's position
        transform.position = pivotTransform.position + offset;

        // Optionally, make the camera look at the pivot
        if (lookAtTarget)
        {
            transform.LookAt(pivotTransform);
        }
    }
}
