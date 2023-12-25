using UnityEngine;

public class Goal : MonoBehaviour
{
    public string scoringTeam; // Set in the Inspector (e.g., "TeamA" or "TeamB")

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("is work?");
            GameManager.instance.GoalScored(scoringTeam);
            // You may also reset the ball's position here if needed.
        }
        else 
        {
            Debug.Log("ded");
        }
    }
}