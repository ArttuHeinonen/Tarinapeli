using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonGameOver : GameOver {

    public GameObject hugeMelon;

    public override void UpdateGameOver()
    {
        if (!waitForAnimation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GameController.Instance.IsDialogFinished())
                {
                    endButtonsPanel.SetActive(true);
                    endText.SetActive(true);
                }
                else
                {
                    AfterScene();
                }
            }
        }
        if (startScoring)
        {
            ScorePlayer();
        }
    }

    public override void ScorePlayer()
    {
        startScoring = false;
        player.transform.position = scoringPosition;
        Score score = GameController.Instance.play.score;
        maxPoints = score.maxScore;
        points = score.currentScore;
        AssignStars();
        ShowStarsBasedOnScore();
    }

    public override void AfterScene()
    {
        hugeMelon.GetComponent<Animator>().SetTrigger("RollOver");
        hugeMelon.GetComponent<Rotate>().isRotating = true;
    }
}
