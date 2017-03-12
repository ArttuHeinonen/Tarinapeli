using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonGameOver : GameOver {

    public override void UpdateGameOver()
    {
        if (!waitForAnimation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GameController.Instance.IsDialogFinished())
                {
                    //Show end buttons
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
        Debug.Log("GameOver Update");
    }

    public override void ScorePlayer()
    {
        
    }

    public override void AfterScene()
    {
        
    }
}
