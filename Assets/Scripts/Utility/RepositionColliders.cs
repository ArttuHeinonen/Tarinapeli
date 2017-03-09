using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionColliders : MonoBehaviour {

    public Camera cam;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject bottomWall;
    public GameObject topWall;

    public float screenWidth;
    public float screenHeight;

    void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 screenLimits = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        screenWidth = screenLimits.x;
        screenHeight = screenLimits.y;
        PositionWalls();
        DeactivateWalls();
	}

    void PositionWalls()
    {
        leftWall.transform.position = new Vector3(-screenWidth, 0, 0);
        rightWall.transform.position = new Vector3(screenWidth, 0, 0);
        bottomWall.transform.position = new Vector3(0, -screenHeight, 0);
        topWall.transform.position = new Vector3(0, topWall.transform.position.y, 0);
    }

    public void ActivateWalls()
    {
        leftWall.SetActive(true);
        rightWall.SetActive(true);
        bottomWall.SetActive(true);
        topWall.SetActive(true);
    }

    public void DeactivateWalls()
    {
        leftWall.SetActive(false);
        rightWall.SetActive(false);
        bottomWall.SetActive(false);
        topWall.SetActive(false);
    }
}
