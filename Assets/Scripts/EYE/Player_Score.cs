using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Score : MonoBehaviour, IScore
{
    //this script is to be placed on an object in the scene(main camera, manager, empty game object)
    //it will be accessed by the targetValue script placed on the target(bubble)

    public int Score { get; set ; }

    public void AddScore(int score)
    {
        Score += score;

        Debug.Log($"Score: {Score}- Player_Score");
    }
}
