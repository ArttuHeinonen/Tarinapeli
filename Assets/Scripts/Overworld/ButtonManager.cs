using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void StagePressed(string sceneName)
    {
        AudioManager.Instance.PlaySound("Button_Click");
        SceneManager.LoadScene(sceneName);
    }
}
