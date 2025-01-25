using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScore
{
    //This is the scoring interface that sets the contract necessary for the score to be increased when target hit by bullet(tag)
    public int Score { get; set; }

    public void AddScore(int score);
}
