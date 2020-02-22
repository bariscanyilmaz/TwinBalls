using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text="Highest Score:"+PlayerPrefs.GetInt("score");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
