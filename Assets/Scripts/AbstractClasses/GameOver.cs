using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameOver : MonoBehaviour {

    public bool waitForAnimation;
    public bool startScoring;
    public GameObject endButtonsPanel;

    void Start()
    {
        waitForAnimation = true;
        startScoring = true;
    }

    public abstract void UpdateGameOver();
    public abstract void AfterScene();
    public abstract void ScorePlayer();

    public void ToggleEndGameButtons(bool visible)
    {
        endButtonsPanel.SetActive(visible);
    }
}
