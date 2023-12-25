using UnityEngine;

public class GoalDetection2 : MonoBehaviour
{
    public GameObject ball;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == ball)
        {
            Collider ballCollider = ball.GetComponent<Collider>();
            Collider goalCollider = GetComponent<Collider>();

            if (IsBallCompletelyInGoal(ballCollider, goalCollider))
            {
                Debug.Log("Team two scores!");
            }
        }
    }

    private bool IsBallCompletelyInGoal(Collider ball, Collider goal)
    {
        Bounds ballBounds = ball.bounds;
        Bounds goalBounds = goal.bounds;

        // Check if the ball is completely inside the goal
        return goalBounds.Contains(new Vector3(ballBounds.min.x, ballBounds.min.y, ballBounds.min.z)) &&
               goalBounds.Contains(new Vector3(ballBounds.max.x, ballBounds.max.y, ballBounds.max.z));
    }
}
