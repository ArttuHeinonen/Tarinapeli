using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour {

	
    public void HomeButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void RetryButtonPressed()
    {
        GameController.Instance.GotoPlaymode();
    }

    public void OverWorldButton()
    {
        SceneManager.LoadScene("Overworld");
    }
}
