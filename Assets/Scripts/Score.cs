using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    //Pontos
    [SerializeField] private Text scoreText;
    private int score;
    [SerializeField] private Text highScoreText;
    private int myHighScore;

    //bools for score
    public bool fourScore;
    public bool fiveScore;
    public bool reverseScore;

    //Panels
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject pausePanel;

    //Scene
    [SerializeField] private int sceneIndex;
    [SerializeField] private int menuIndex;
    public int scoreToBeat;

    //bool
    private bool stopWinPanel = false;

    //Instance to use funcion in other script
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
        if (fourScore)
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        if (fiveScore)
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore1", 0).ToString();
        }
        if (reverseScore)
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore2", 0).ToString();
        }

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.DeleteAll();
        }
        LosePanel();
    }

    public void ScoreUpdate(int scoreIn)
    {
        score += scoreIn;
        scoreText.text = score.ToString();

        if (fourScore)
        {
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                myHighScore = score;
                highScoreText.text = myHighScore.ToString();
                PlayerPrefs.SetInt("HighScore", myHighScore);
            }
        }

        if (fiveScore)
        {
            if (score > PlayerPrefs.GetInt("HighScore1", 0))
            {
                myHighScore = score;
                highScoreText.text = myHighScore.ToString();
                PlayerPrefs.SetInt("HighScore1", myHighScore);
            }
        }

        if (reverseScore)
        {
            if (score > PlayerPrefs.GetInt("HighScore2", 0))
            {
                myHighScore = score;
                highScoreText.text = myHighScore.ToString();
                PlayerPrefs.SetInt("HighScore2", myHighScore);
            }
        }
    }

    public void WinPanel(int scoreToWin)
    { 
        if(scoreToWin == scoreToBeat && stopWinPanel == false)
        {
            winPanel.SetActive(true);
            GameControl.canMove = false;
        }
    }

    private void LosePanel()
    {
        if(GameControl.lost == true)
        {
            losePanel.SetActive(true);
            GameControl.canMove = false;
        }
    }

    public void Pause()
    {
        GameControl.canMove = false;
        pausePanel.SetActive(true);
    }

    public void ClosePause()
    {
        pausePanel.SetActive(false);
        GameControl.canMove = true;
    }

    public void Restart()
    {
        GameControl.canMove = true;
        GameControl.lost = false;
        winPanel.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }
    public void Contine()
    {
        winPanel.SetActive(false);
        GameControl.canMove = true;
        stopWinPanel = true;
    }

    public void RestartLose()
    {
        GameControl.canMove = true;
        GameControl.lost = false;
        losePanel.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(menuIndex);
    }

}
