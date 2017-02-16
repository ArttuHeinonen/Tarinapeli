using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Score : MonoBehaviour {

	void Start () {
		
	}

    public abstract string GetGradeText();

    public void UpdateScoreText()
    {

    }
}
