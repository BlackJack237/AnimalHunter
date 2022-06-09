using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private Texture2D mouseCursor;
    [SerializeField] private TMP_Text scoreText;
    
    private int score;
    private void Start()
    {
        Cursor.SetCursor(mouseCursor,new Vector2(mouseCursor.width/2,mouseCursor.height/2),CursorMode.Auto);
        scoreText.text = "0";
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
}
