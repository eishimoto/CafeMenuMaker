using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;

    public static Score instance;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ScoreUpdate(int scoreIn)
    {
        score = scoreIn;
        scoreText.text = score.ToString();
    }
}
