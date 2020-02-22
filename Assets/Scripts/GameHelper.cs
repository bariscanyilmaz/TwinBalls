using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHelper : MonoBehaviour
{
     private int score;
    private int highestScore;
    public int Score{get{return score;}}
    public TextMeshProUGUI scoreText;
    private static GameHelper _gameHelper;

    public static GameHelper gameManager { get { return _gameHelper; } }

    void Awake()
    {

        if (_gameHelper == null)
        {
            _gameHelper = this;
        }

        highestScore=PlayerPrefs.GetInt("score");
    }


    public void IncreaseScore(int score)
    {
        this.score+=score;
        if (score>highestScore)
        {
            PlayerPrefs.SetInt("score",score);
        }
    }

    private void FixedUpdate()
    {
        scoreText.text="Score:"+score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Time.timeScale=0;
    }
}
