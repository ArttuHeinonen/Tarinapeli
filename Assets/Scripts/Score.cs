using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public static Score Instance { get; private set; }

    public Text scoreText;
    public int scoreValue = 1;
    private int score = 0;

	void Start () {
        Instance = this;
        score = 0;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Melon")
        {
            score += scoreValue;
        }
        else
        {
            score -= scoreValue;
            preventNegativeScore();
        }
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void preventNegativeScore()
    {
        if(score < 0)
        {
            score = 0;
        }
    }
}
