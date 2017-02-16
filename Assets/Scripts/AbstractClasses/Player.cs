using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

    private bool canControl = false;

    void Start () {
		
	}

    public void ToggleControl(bool control)
    {
        canControl = control;
    }


}
