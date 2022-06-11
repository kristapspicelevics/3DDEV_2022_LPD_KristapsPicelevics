using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public int score = 0;
    int highscore = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 20000);
        scoreText.text = "SCORE: " + score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {
        scoreText.text = "SCORE: " + score.ToString();
        if (score > highscore)
            highscore = PlayerPrefs.GetInt("highscore", score);
    }

}
