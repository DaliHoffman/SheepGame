using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    public int highScore = 0;
    public Text highScoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public void SaveHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
