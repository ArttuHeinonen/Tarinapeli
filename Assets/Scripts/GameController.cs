using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController Instance { get; private set; }

    public enum GameState { title, playing, cutScene, animation, gameover};
    private GameState gameState;

    public Camera cam;
    public GameObject[] pickups;
    public GameObject gameOverText;
    public GameObject resetButton;
    public GameObject homeButton;
    public GameObject nextButton;
    public GameObject titleScreen;
    public Text timerText;
    public Text scoreText;
    public DialogueController dialogController;

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
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float melonWidth = pickups[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - melonWidth;
        GotoTitleScreen();
    }

    public void StartCutScene()
    {
        titleScreen.SetActive(false);
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.title:
                UpdateTitle();
                break;
            case GameState.playing:
                UpdatePlaying();
                break;
            case GameState.cutScene:
                UpdateCutScene();
                break;
            case GameState.animation:
                UpdateAnimation();
                break;
            case GameState.gameover:
                GameOver();
                break;
            default:
                break;
        }
    }

    private void UpdateTitle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            titleScreen.SetActive(false);
            dialogController.ShowCurrentLine();
            gameState = GameState.cutScene;
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
        if (Input.GetMouseButtonDown(0))
        {
            if(dialogController.currentLine == 2)
            {
                PlayerController.Instance.AnimateSearch();
            }

            dialogController.ShowNextLine();
            if (dialogController.isFinished)
            {
                GotoPlaymode();
            }
        }
    }

    private void UpdateAnimation()
    {

    }

    private void GotoTitleScreen()
    {
        gameState = GameState.title;
        titleScreen.SetActive(true);
        gameOverText.SetActive(false);
        timerText.text = "";
        dialogController.HideDialog();
        scoreText.text = "";
        PlayerController.Instance.ToggleControl(false);
        HideGameOver();
        
    }

    private void GotoPlaymode()
    {
        gameState = GameState.playing;
        titleScreen.SetActive(false);
        PlayerController.Instance.ToggleControl(true);
        Score.Instance.UpdateScoreText();
        StartCoroutine(Spawn());
    }

    private void HideGameOver()
    {
        gameOverText.SetActive(false);
        resetButton.SetActive(false);
        homeButton.SetActive(false);
        nextButton.SetActive(false);
    }

    private void UpdateTimerText()
    {
        timerText.text = "Aikaa: " + Mathf.RoundToInt(timeLeft);
    }

    IEnumerator Spawn()
    {
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
        PlayerController.Instance.ToggleControl(false);
    }
}
