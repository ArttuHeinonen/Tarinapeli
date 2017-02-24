using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	


	void Start () {
		
	}


    public void StagePressed(string sceneName)
    {
        AudioManager.Instance.PlaySound("Click");
        SceneManager.LoadScene(sceneName);
    }
}
