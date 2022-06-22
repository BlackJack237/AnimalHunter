using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private Texture2D mouseCursor;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip highScoreClip;

    private AudioSource audioSource;
    private int score;
    private int currentHighscore;
    private float timer;
    
    private float gameTimer = 30f;
    private void Start()
    {
        Cursor.SetCursor(mouseCursor,new Vector2(mouseCursor.width/2,mouseCursor.height/2),CursorMode.Auto);
        scoreText.text = "0";
        gameOverScreen.SetActive(false);
        currentHighscore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = currentHighscore.ToString();
        audioSource = GetComponent<AudioSource>();
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
            SetHighscore();
            Time.timeScale = 0f;
        }
        timerText.text = System.Math.Round(gameTimer-timer, 2).ToString();
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

    private void SetHighscore()
    {
        if (score > currentHighscore)
        {
            audioSource.PlayOneShot(highScoreClip);
            PlayerPrefs.SetInt("Highscore",score);
            currentHighscore = score;
            highScoreText.text = score.ToString();
        }
    }
    public void RestartGame()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        timer = 0f;
    }

    
}
