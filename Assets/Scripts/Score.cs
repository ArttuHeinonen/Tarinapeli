using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static Score Instance { get; private set; }

    public Text scoreText;
    public int scoreValue = 1;
    public int score = 0;

    void Start()
    {
        Instance = this;
        score = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Melon")
        {
            score += scoreValue;
            EatPickup(other);
        }
        else if (other.gameObject.tag == "IceCream")
        {
            score -= scoreValue;
            PreventNegativeScore();
            EatPickup(other);
        }
        UpdateScoreText();
    }

    public void HideScoreText()
    {
        scoreText.text = "";
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    void PreventNegativeScore()
    {
        if (score < 0)
        {
            score = 0;
        }
    }

    void EatPickup(Collider2D other)
    {
        PlayerController.Instance.AnimateEating();
        Destroy(other.gameObject);
    }
}
