using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {

    public void RestartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void GoStageSelector()
    {
        SceneManager.LoadScene("");
    }
}
