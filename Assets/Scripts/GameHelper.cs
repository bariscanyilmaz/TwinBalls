using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    private int score;
    private int coin;
    private int highestScore;
    public int Score { get { return score; } }
    public int Coin { get { return coin; } }
    public int HighestScore { get { return highestScore; } }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gameStatusText;
    public TextMeshProUGUI highestScoreText;
    public GameObject panel;
    public GameObject resumeButton;

    public GameSoundScript gameSoundManager;

    private static GameHelper _gameHelper;


    public static GameHelper gameManager { get { return _gameHelper; } }

    void Awake()
    {

        if (_gameHelper == null)
        {
            _gameHelper = this;
        }

        highestScore = PlayerPrefs.GetInt("score");
        coin = PlayerPrefs.GetInt("coin");
        //panel=GameObject.FindGameObjectWithTag("Panel");

    }


    public void IncreaseScore(int score)
    {
        this.score += score;
        gameSoundManager.BonusPlay();
        if (Score > HighestScore)
        {
            highestScore=this.Score;
            PlayerPrefs.SetInt("highestScore", HighestScore);
            PlayerPrefs.SetInt("score", Score);
        }
    }

    private void Update()
    {
        scoreText.text = "Score:" + score;
        coinText.text = "Coin:" + coin;
    }

    public void RestartGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        gameSoundManager.PauseGamePlay();
        gameSoundManager.FailurePlay();
        panel.SetActive(true);
        resumeButton.SetActive(false);
        gameStatusText.text = "Game Over";
        highestScoreText.text="Highest Score:"+HighestScore;
        Time.timeScale = 0;
    }

    public void IncreaseCoin()
    {
        coin++;
        gameSoundManager.CoinPlay();
        PlayerPrefs.SetInt("coin", coin);
    }

    public void PauseGame()
    {
        
        gameSoundManager.PauseGamePlay();
        resumeButton.SetActive(true);
        gameStatusText.text = "Pause";
        highestScoreText.text="Highest Score:"+HighestScore;
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void ResumeGame()
    {
        gameSoundManager.ResumeGamePlay();
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Time.timeScale=1;
        panel.SetActive(false);
        SceneManager.LoadScene("HomeScene");
    }
}
