using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score = 0;

    public void IncrementScore(int amount)
    {
        score += amount;
        Debug.Log(score);
    }
}
