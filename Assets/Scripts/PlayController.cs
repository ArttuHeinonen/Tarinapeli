using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayController : MonoBehaviour {

    private Camera cam;
    public GameObject[] pickups;
    public GameObject DroppingOwl;
    public Transform[] spawnPoints;
    public Slider timer;

    private float maxTime = 40;
    public float timeLeft;
    public float minSpawnTime;
    public float maxSpawnTime;
    private float maxWidth;
    public int totalSpawns = 0;

    void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }
        timeLeft = maxTime;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        if(pickups.Length > 0)
        {
            float melonWidth = pickups[0].GetComponent<Renderer>().bounds.extents.x;
            maxWidth = targetWidth.x - melonWidth;
        }
        ResetTime();
    }

    public void UpdatePlayMode()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                UpdateMelon();
                break;
            case "UnderwaterScene":
                UpdateUnderWater();
                break;
            default:
                break;
        }

        if(timer != null)
        {
            UpdateTimer();
        }
    }

    public void ActivateSpawn()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                StartCoroutine(SpawnMelon());
                break;
            case "UnderwaterScene":
                StartCoroutine(SpawnBlowfish());
                break;
            default:
                break;
        }
    }

    public void ActivateMusic()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                SoundManager.Instance.PlayMelonGameMusic();
                break;
            case "UnderwaterScene":
                SoundManager.Instance.PlayUnderWaterMusic();
                break;
            default:
                break;
        }
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
    private void UpdateMelon()
    {
        PlayerController.Instance.MelonUpdate();
    }
    private void UpdateUnderWater()
    {
        PlayerController.Instance.UnderWaterUpdate();
    }

    void UpdateTimerText()
    {
        timer.value = Mathf.RoundToInt(timeLeft);
    }

    public IEnumerator SpawnMelon()
    {
        totalSpawns = 0;
        setSpawnTimers(1, 2);
        yield return new WaitForSeconds(1f);
        while (timeLeft > 0)
        {
            GameObject pickup = pickups[Random.Range(0, pickups.Length)];
            if (totalSpawns == 5)
            {
                pickup = DroppingOwl;
            }
            if (pickup.CompareTag("Melon"))
            {
                Score.Instance.AddMaxScore();
            }
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0f);
            totalSpawns++;
            addDifficulty(10, 0.3f);
            Instantiate(pickup, spawnPosition, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
        yield return new WaitForSeconds(3f);
        PlayerController.Instance.ResetPlayerXPosition();
        GameController.Instance.GoToGameOver();
    }

    public IEnumerator SpawnBlowfish()
    {
        setSpawnTimers(3, 3);
        totalSpawns = 0;
        while (timeLeft > 6 && Score.Instance.lives > 0)
        {
            if(totalSpawns == 5)
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
        if(Score.Instance.lives > 0)
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
        if(minSpawnTime <= 0)
        {
            minSpawnTime = 0.1f;
        }
        if(maxSpawnTime <= minSpawnTime)
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
        Score.Instance.ResetScores();
    }
}
