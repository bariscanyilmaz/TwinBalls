using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{

    private int score;
    public int Score{get{return score;}}
    public TextMeshProUGUI scoreText;
    private static GameManager _gameManager;

    public static GameManager gameManager { get { return _gameManager; } }

    void Awake()
    {

        if (_gameManager == null)
        {
            _gameManager = this;
        }

        score=PlayerPrefs.GetInt("score");
    }


    public void IncreaseScore(int score)
    {
        this.score+=score;
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
