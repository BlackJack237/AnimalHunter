using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private Texture2D mouseCursor;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private float gameTimer = 30f;
    
    private int score;
    private float timer;

    private void Start()
    {
        Cursor.SetCursor(mouseCursor,new Vector2(mouseCursor.width/2,mouseCursor.height/2),CursorMode.Auto);
        scoreText.text = "0";
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        timer += Time.deltaTime;

        if (timer >= gameTimer)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void AddScore(int scorePointsToAdd)
    {
        if (CheckIfPossibleScorePoints(scorePointsToAdd))
        {
            score = score + scorePointsToAdd;
            scoreText.text = score.ToString();
            return;
        }
        Debug.LogError("Can`t add negative ScorePoints");
    }

    private bool CheckIfPossibleScorePoints(int scorePoints)
    {
        return scorePoints > 0;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        timer = 0f;
    }
}
