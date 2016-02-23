﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance { get; private set; }

    public Camera cam;
    private float maxWidth;
    private bool canControl;
    private Animator anim;

    void Start () {
        Instance = this;
	    if(cam == null)
        {
            cam = Camera.main;
        }
        canControl = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        maxWidth = targetWidth.x;
        anim = GetComponentInChildren<Animator>();
    }

	void Update () {
        if (canControl)
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, 0f, 0f);
            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            transform.position = new Vector3(targetWidth, transform.position.y);
        }
	}

    public void ToggleControl(bool toggle)
    {
        canControl = toggle;
    }

    public void AnimateSearch()
    {
        anim.SetTrigger("Search");
    }
}
