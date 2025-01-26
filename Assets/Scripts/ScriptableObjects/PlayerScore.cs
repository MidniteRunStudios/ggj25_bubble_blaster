using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScore", menuName = "ScriptableObjects/PlayerScore", order = 2)]

public class PlayerScore : ScriptableObject, IScore
{
    public int Score { get => _score; set => _score = value; }
    [SerializeField] private int _score;
    public void AddScore(int score)
    {
        _score += score;
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
