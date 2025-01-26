using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScore
{
    public int Score { get; }
    public void AddScore(int score);
    public void ResetScore();
}
