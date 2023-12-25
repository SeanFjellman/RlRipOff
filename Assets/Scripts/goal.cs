using UnityEngine;



public class Goal : MonoBehaviour
{
    private collision test;

    public string scoringTeam; // Set in the Inspector (e.g., "TeamA" or "TeamB")

    void Update()
    {
        OnCollisionEnter(test);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("is");
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