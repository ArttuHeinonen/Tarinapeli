using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameOver : MonoBehaviour {

    public bool waitForAnimation;
    public bool startScoring;
    public GameObject endButtonsPanel;
    public GameObject endText;
    public GameObject player;
    public Vector3 scoringPosition = new Vector3(0, -2f, 0);
    public int stars;
    public int points;
    public int maxPoints;
    public float percent;
    public GameObject starImages;

    void Start()
    {
        waitForAnimation = true;
        startScoring = true;
        HideAllStars();
        endButtonsPanel.SetActive(false);
        endText.SetActive(false);
    }

    public abstract void UpdateGameOver();
    public abstract void AfterScene();
    public abstract void ScorePlayer();

    public void ToggleEndGameButtons(bool visible)
    {
        endButtonsPanel.SetActive(visible);
    }

    public void AssignStars()
    {
        percent = (float)points / (float)maxPoints;

        if(percent < 0.25f)
        {
            stars = 0;
        }
        else if (percent < 0.5f)
        {
            stars = 1;
        }
        else if(percent < 0.75f)
        {
            stars = 2;
        }
        else if(percent <= 1.0f)
        {
            stars = 3;
        }
        else
        {
            Debug.Log("Scoring went wrong! It's not on the scale at all! Percent:" + percent + ", Points: " + points + ", MaxPoints: " + maxPoints);
        }
    }

    public void ShowStarsBasedOnScore()
    {
        for (int i = 0; i < stars; i++)
        {
            StartCoroutine(MakeStarAppear(starImages.transform.GetChild(i).gameObject));
        }
        waitForAnimation = false;
    }

    public void HideAllStars()
    {
        for (int i = 0; i < starImages.transform.childCount; i++)
        {
            starImages.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public IEnumerator MakeStarAppear(GameObject star)
    {
        star.SetActive(true);
        //Start animation
        //Make sound
        //Spawn particles
        yield return new WaitForEndOfFrame();
    }
}
