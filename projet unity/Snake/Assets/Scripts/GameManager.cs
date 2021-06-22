using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    public Text highscoreText;


    int score = 0;
    int highscore = 0;
    


    void Start()
    {
        if (instance == null)
        {

            instance = this;
        }
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
 
    }

    public void Add(int SC)
    {
        score += SC;
        scoreText.text = "SCORE: " + score.ToString() ;

        if (highscore < score)
        PlayerPrefs.SetInt("highscore",score);
    }
}
