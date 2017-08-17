using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreTextInGame;
    public Text scoreTextEndGame;
    public Text highScoreText;
    public GameObject newHighScoreText;
    public int score;
    float oldHeight;
    float height;

	void Start () {
        scoreTextInGame.text = "0";
        oldHeight = 0;
	}
	
	void Update () {
        height = gameObject.transform.position.y;

        if(height > oldHeight)
        {
            score = (int) Mathf.Round(height * 1.3333333f);
            scoreTextInGame.text = score.ToString();
        }
        oldHeight = height;

	}
    public void setEndScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreTextEndGame.text = scoreTextInGame.text;
        highScoreText.text = "Best " + highScore.ToString();
        if (highScore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            newHighScoreText.SetActive(true);
            highScoreText.text = "Previous Best " + highScore.ToString();
        }

    }
}
