using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHelper : MonoBehaviour
{
    private int score;
    private int coin;
    private int highestScore;
    public int Score { get { return score; } }
    public int Coin { get { return coin; } }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    

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
    }


    public void IncreaseScore(int score)
    {
        this.score += score;
        if (score > highestScore)
        {
            PlayerPrefs.SetInt("score", score);
        }
    }

    private void Update()
    {
        scoreText.text = "Score:" + score;
        coinText.text = "Coin:" + coin;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }

    public void IncreaseCoin()
    {
        coin++;
        PlayerPrefs.SetInt("coin",coin);
    }
}
