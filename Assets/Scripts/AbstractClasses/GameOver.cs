using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameOver : MonoBehaviour {

    public bool waitForAnimation;
    public GameObject endButtonsPanel;

    void Start()
    {
        waitForAnimation = false;
    }

    public abstract void UpdateGameOver();

    public void ToggleEndGameButtons(bool visible)
    {
        endButtonsPanel.SetActive(visible);
    }
}
