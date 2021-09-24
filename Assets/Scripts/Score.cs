using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;

    [SerializeField] private Text highScoreText;
    public int myHighScore;

    public static Score instance;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void ScoreUpdate(int scoreIn)
    {
        score += scoreIn;
        scoreText.text = score.ToString();

        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            myHighScore = score;
            highScoreText.text = myHighScore.ToString();
            PlayerPrefs.SetInt("HighScore", myHighScore);
        }
    }
}
