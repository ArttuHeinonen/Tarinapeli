using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public static Score Instance { get; private set; }

    public Text scoreText;
    public int maxScore = 0;
    public float grade;
    public int score = 0;
    public int stars = 0;
    public int lives = 3;
    public int maxLives = 3;

    void Start()
    {
        Instance = this;
        score = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                CheckPickUpCollision(other);
                break;
            case "UnderwaterScene":
                CheckEnemyCollision(other);
                break;
            default:
                break;
        }
        UpdateScoreText();
    }

    void CheckPickUpCollision(Collider2D other)
    {
        if (other.gameObject.CompareTag("Melon"))
        {
            score++;
            EatPickup(other);
        }
        else if (other.gameObject.CompareTag("IceCream"))
        {
            EatPickup(other);
        }
    }

    void CheckEnemyCollision(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blowfish"))
        {
            lives--;
            HitEnemy(other);
        }
    }
    public void HideScoreText()
    {
        scoreText.text = "";
    }

    public void UpdateScoreText()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                scoreText.text = score.ToString();
                break;
            case "UnderwaterScene":
                scoreText.text = lives.ToString();
                break;
            default:
                break;
        }  
    }

    void GradeByScore()
    {
        if(maxScore > 0)
        {
            grade = (float)score / (float)maxScore;
        }
        CalculateStars();
    }

    void GradeByLives()
    {
        if(maxLives > 0)
        {
            grade = (float)lives / (float)maxLives;
        }
        CalculateStars();
    }

    void CalculateStars()
    {
        if (grade < 0.3)
        {
            stars = 0;
        }
        else if (grade < 0.5)
        {
            stars = 1;
        }
        else if (grade < 0.75)
        {
            stars = 2;
        }
        else if (grade >= 0.75)
        {
            stars = 3;
        }
    }

    string MelonGradeText()
    {
        if (stars == 0)
        {
            PlayerController.Instance.ChangeSpriteToHungry();
            return GameController.Instance.lang.getString("melonBadEnd");
        }
        else if (stars == 1 || stars == 2)
        {
            return GameController.Instance.lang.getString("melonGoodEnd");
        }
        else
        {
            PlayerController.Instance.ChangeSpriteToHappy();
            return GameController.Instance.lang.getString("melonGreatEnd");
        }
    }

    string UnderwaterGradeText()
    {
        PlayerController.Instance.ResetPlayerYPosition();
        if (stars == 0)
        {
            return GameController.Instance.lang.getString("underwaterBadEnd");
        }
        else
        {
            PusuController.Instance.Animate("PusuMoveToOo");
            return GameController.Instance.lang.getString("underwaterGoodEnd");
        }
    }

    public string GetGradeText()
    {
        string value = "Error";

        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                GradeByScore();
                value = MelonGradeText();
                break;
            case "UnderwaterScene":
                GradeByLives();
                value = UnderwaterGradeText();
                break;
            default:
                break;
        }

        return value;
    }

    void EatPickup(Collider2D other)
    {
        if (other.gameObject.CompareTag("Melon"))
        {
            PlayerController.Instance.Animate("Eat");
        }
        else if (other.gameObject.CompareTag("IceCream"))
        {
            PlayerController.Instance.Animate("Freeze");
        }
        
        Destroy(other.gameObject);
    }

    void HitEnemy(Collider2D other)
    {
        PlayerController.Instance.Animate("TakeDamage");

        Destroy(other.gameObject);
    }

    public void AddMaxScore()
    {
        maxScore++;
    }

    public void ResetScores()
    {
        scoreText.text = "";
        score = 0;
        maxScore = 0;
        grade = 0f;
        stars = 0;
        lives = maxLives;
    }

    public int getStars()
    {
        return this.stars;
    }
}
