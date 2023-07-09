using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreByTime : MonoBehaviour {

    public int score = 0;
    private float timer = 0.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start () {
        // Load highscore from player prefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Display highscore on TMPro
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    void Update () {
        timer += Time.deltaTime;

        if(timer > 1f) {
            score++;
            timer = 0.0f;

            // Check and update highscore
            if (score > PlayerPrefs.GetInt("HighScore", 0)) {
                PlayerPrefs.SetInt("HighScore", score);

                // Display updated highscore on TMPro
                highScoreText.text = "Highscore: " + score.ToString();
            }
        }

        scoreText.text = "Score: " + score.ToString();
    }
}
