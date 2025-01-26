using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScore", menuName = "ScriptableObjects/PlayerScore", order = 2)]

public class PlayerScore : ScriptableObject, IScore
{
    public int Score { get; set; }

    public void AddScore(int score)
    {
        Score += score;
    }

    public void ResetScore()
    {
        Score = 0;
    }
}
