using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Score : MonoBehaviour {

    public int currentScore;
    public int maxScore;
    public string grade;

    public abstract string GetScoreText();

    public abstract string GetGradeText(int stars, string sceneName);

    public abstract void UpdateScoreText();

    public abstract void ResetScore();

    public abstract void IncreaseScore();

    public abstract void DecreaseScore();
}
