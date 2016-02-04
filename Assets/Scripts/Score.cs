using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int scoreValue;
    private int score = 0;

	void Start () {
        score = 0;
        UpdateScoreText();
	}

    void OnTriggerEnter2D()
    {
        score += scoreValue;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
