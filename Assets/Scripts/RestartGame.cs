using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	public void RestartLevel()
    {
        SceneManager.LoadScene("Scene1");
    }
}
