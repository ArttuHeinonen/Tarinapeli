using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MelonButtons : MonoBehaviour {

	
    public void HomeButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

}
