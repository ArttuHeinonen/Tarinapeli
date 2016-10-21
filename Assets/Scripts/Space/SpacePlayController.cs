using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpacePlayController : MonoBehaviour {

    private Camera cam;
    public GameObject SpaceOwl;
    public Transform[] spawnPoints;
    public Slider timer;

    private float maxTime = 40;
    public float timeLeft;
    public float minSpawnTime;
    public float maxSpawnTime;
    private float maxWidth;
    public int totalSpawns = 0;

    private bool canControl = false;
    private Animator anim;

    void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }
        timeLeft = maxTime;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        ResetTime();
    }
	
	void Update () {
	


	}

    public void ResetTime()
    {
        timer.maxValue = maxTime;
        timer.value = maxTime;
        timeLeft = maxTime;
    }

    public void Reset()
    {
        ResetTime();
        Score.Instance.ResetScores();
    }
}
