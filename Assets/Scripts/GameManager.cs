using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState GameState;
    public PlayerScore PlayerScore;
    public PlayerScore HighScore;
    public TMP_Text Intro_Text;
    public TMP_Text Score_Text;
    public TMP_Text GameOver_Text;
    public TMP_Text NewHighScore_Text;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        GameState.isPlaying = false;
        PlayerScore.ResetScore();
        Score_Text.enabled = false;
        Intro_Text.enabled = true;
        GameOver_Text.enabled = false;
        NewHighScore_Text.enabled = false;
    }

    private void Update()
    {
        Score_Text.text = PlayerScore.Score.ToString();
        if (GameState == null)
        {
            return;
        }

        if (!GameState.isPlaying && Input.anyKey)
        {
            GameState.isPlaying = true;
            Intro_Text.enabled = false;
            Score_Text.enabled = true;
        }
    }

    public void EndGame()
    {
        GameState.isPlaying = false;
        Score_Text.enabled = false;
        GameOver_Text.enabled = true;
        GameOver_Text.text = "GAME" + Environment.NewLine + "OVER" + Environment.NewLine + Environment.NewLine + "SCORE: " +  PlayerScore.Score; 
        if (PlayerScore.Score > HighScore.Score)
        {
            NewHighScore_Text.enabled = true;
            HighScore.Score = PlayerScore.Score;
        }
    }
}
