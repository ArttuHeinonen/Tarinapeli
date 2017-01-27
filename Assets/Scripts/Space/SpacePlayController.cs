using System.Collections;
using UnityEngine;
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
	
	public void UpdatePlayMode()
    {
        SpacePlayerController.Instance.Update();
	}

    private void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        timer.value = Mathf.RoundToInt(timeLeft);
    }

    public void ActivateSpawn()
    {
        StartCoroutine(SpawnTrash());
    }

    public void ActivateMusic()
    {
        SoundManager.Instance.PlaySpaceGameMusic();
    }

    public IEnumerator SpawnTrash()
    {
        setSpawnTimers(3, 3);
        totalSpawns = 0;
        while (timeLeft > 6 && Score.Instance.lives > 0)
        {
            if (totalSpawns == 5)
            {
                Spawner.Instace.SpawnOwl();
            }
            else
            {
                Spawner.Instace.Spawn();
            }
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            totalSpawns++;
            addDifficulty(4, 0.5f);
        }
        if (Score.Instance.lives > 0)
        {
            yield return new WaitForSeconds(7f);
        }
        GameController.Instance.GoToGameOver();
    }

    void setSpawnTimers(float min, float max)
    {
        this.minSpawnTime = min;
        this.maxSpawnTime = max;
    }

    void addDifficulty(int interval, float addedChallenge)
    {
        if (totalSpawns % interval == 0 && minSpawnTime > 0.1f)
        {
            minSpawnTime -= addedChallenge;
            maxSpawnTime -= addedChallenge;
        }
        if (minSpawnTime <= 0)
        {
            minSpawnTime = 0.1f;
        }
        if (maxSpawnTime <= minSpawnTime)
        {
            maxSpawnTime = minSpawnTime;
        }
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
        SpaceScore.Instance.ResetScores();
    }
}
