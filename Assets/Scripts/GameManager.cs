using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameState GameState;
    public PlayerScore PlayerScore;
    public PlayerScore HighScore;
    public TMP_Text Intro_Text;
    public TMP_Text Score_Text;
    public TMP_Text GameOver_Text;
    public TMP_Text NewHighScore_Text;
    public int targetSceneIndex = -1;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        GameState.isPlaying = false;
        GameState.LevelComplete = false;
        PlayerScore.ResetScore();
        Score_Text.enabled = false;
        Intro_Text.enabled = true;
        GameOver_Text.enabled = false;
        NewHighScore_Text.enabled = false;
    }

    private void Update()
    {
        if (GameState == null)
        {
            return;
        }

        UpdateUI();

        CheckQuit();

        CheckStart();
        CheckComplete();
    }

    private void UpdateUI()
    {
        Score_Text.text = PlayerScore.Score.ToString();
    }

    private void CheckComplete()
    {
        if (GameState.LevelComplete)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && targetSceneIndex != -1)
            {
                SceneManager.LoadScene(targetSceneIndex);
            }
        }
    }

    private void CheckStart()
    {
        if (!GameState.isPlaying && !GameState.LevelComplete && Input.anyKey)
        {
            GameState.isPlaying = true;
            Intro_Text.enabled = false;
            Score_Text.enabled = true;
        }
    }

    private static void CheckQuit()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void EndGame()
    {
        CompleteLevel();
        UpdateText();
        UpdateScores();
    }

    private void UpdateScores()
    {
        if (PlayerScore.Score > HighScore.Score)
        {
            NewHighScore_Text.enabled = true;
            HighScore.Score = PlayerScore.Score;
        }
    }

    private void UpdateText()
    {
        Score_Text.enabled = false;
        GameOver_Text.enabled = true;
        GameOver_Text.text = 
            "GAME" + Environment.NewLine + 
            "OVER" + Environment.NewLine + 
            Environment.NewLine + 
            "SCORE: " + PlayerScore.Score;
    }

    private void CompleteLevel()
    {
        GameState.isPlaying = false;
        GameState.LevelComplete = true;
    }
}
