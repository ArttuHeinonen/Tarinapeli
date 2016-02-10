using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Instance { get; private set; }

    public Camera cam;
    public GameObject[] pickups;
    public GameObject gameOverText;
    public GameObject resetButton;
    public GameObject titleScreen;
    public GameObject startButton;
    public Text timerText;
    public PlayerController playerController;
    private bool playing;
    private bool inCutscene;
    private bool isAnimationPlaying;

    public float timeLeft = 10;
    public float minSpawnTime, maxSpawnTime;
    private float maxWidth;

    void Start()
    {
        Instance = this;
        if(cam == null)
        {
            cam = Camera.main;
        }
        playing = false;
        inCutscene = false;
        isAnimationPlaying = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float melonWidth = pickups[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - melonWidth;
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        startButton.SetActive(false);
        playerController.ToggleControl(true);
        Score.Instance.UpdateScoreText();
        StartCoroutine(Spawn());
    }

    public void StartCutScene()
    {
        titleScreen.SetActive(false);
        startButton.SetActive(false);
    }

    void FixedUpdate()
    {
        if (playing)
        {
            UpdatePlaying();
        }
        else
        {
            UpdateCutScene();
        }
    }

    private void UpdatePlaying()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        UpdateTimerText();
    }

    private void UpdateCutScene()
    {
        if (isAnimationPlaying)
        {
            //Play animation
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Display next text/animation
            }
        }
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time left: " + Mathf.RoundToInt(timeLeft);
    }

    IEnumerator Spawn()
    {
        playing = true;
        yield return new WaitForSeconds(1f);
        while(timeLeft > 0){
            GameObject pickup = pickups[Random.Range(0, pickups.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0f);
            Instantiate(pickup, spawnPosition, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
        yield return new WaitForSeconds(1f);
        GameOver();        
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        resetButton.SetActive(true);
        playerController.ToggleControl(false);
    }
}
