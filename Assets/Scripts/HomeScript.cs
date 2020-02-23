using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    void Start()
    {
        scoreText.text="Highest Score:"+PlayerPrefs.GetInt("highestScore");
        coinText.text="Coin:"+PlayerPrefs.GetInt("coin");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
