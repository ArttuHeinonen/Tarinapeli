using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingScore : Score {

    public GameObject pickupParent;
    public List<GameObject> pickups;

    public Text scoreText;
    public int currentScore;
    public int maxScore;

    public override string GetGradeText()
    {
        return scoreText.text;
    }

    
    void Start () {
		if(pickupParent != null)
        {
            for (int i = 0; i < pickupParent.transform.childCount; i++)
            {
                pickups.Add(pickupParent.transform.GetChild(i).gameObject);
                if (pickupParent.transform.GetChild(i).transform.GetChild(0).tag == "PickupPoint"){
                    maxScore++;
                }
            }
            currentScore = 0;
            UpdateScoreText();
        }
	}

    public override void UpdateScoreText()
    {
        scoreText.text = currentScore + " / " + maxScore;
    }

    public override void ResetScore()
    {
        currentScore = 0;
        UpdateScoreText();
    }

    public override void IncreaseScore()
    {
        currentScore++;
        if(currentScore > maxScore)
        {
            currentScore = maxScore;
        }
        UpdateScoreText();
    }

    public override void DecreaseScore()
    {
        throw new NotImplementedException();
    }
}
