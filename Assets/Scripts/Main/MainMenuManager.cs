using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public static MainMenuManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {

        if (!DataManager.Instance.DoesSaveFileExist())
        {
            
            SceneManager.LoadScene("Intro");
        }
        

	}
	
	void Update () {
		
	}
}
