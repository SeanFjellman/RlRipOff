using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public int teamAScore = 0;
    public int teamBScore = 0;

    public Text teamAScoreText;
    public Text teamBScoreText;

    private void Awake() //kill if already running
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GoalScored(string scoringTeam)
    {
        if (scoringTeam == "TeamA")
        {
            teamAScore++;
        }
        else if (scoringTeam == "TeamB")
        {
            teamBScore++;
        }

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        Debug.Log("Team A Score: " + teamAScore + " | Team B Score: " + teamBScore);
    }
}
