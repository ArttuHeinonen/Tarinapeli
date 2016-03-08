using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController Instance { get; private set; }

    public enum GameState { title, playing, cutScene, gameover};
    public GameState gameState;

    public bool debug = true;
    private Camera cam;
    public GameObject canvasText;
    public GameObject canvasGame;
    public GameObject canvasEnd;
    public GameObject canvasTitle;
    private CutsceneController cutsceneController;
    private PlayController playController;
    public Lang lang;

    void Start()
    {
        Instance = this;
        if(cam == null)
        {
            cam = Camera.main;
        }
        playController = GetComponent<PlayController>();
        cutsceneController = GetComponent<CutsceneController>();
        InitLanguage();
        if (SceneManager.GetActiveScene().name == "MelonScene")
        {
            GotoTitleScreen();
        }
        else
        {
            GoToCutScene();
        }
        
    }

    void InitLanguage()
    {
        if (lang == null)
        {
            if (PlayerPrefs.HasKey("Language"))
            {
                lang = new Lang((TextAsset)Resources.Load("System"), PlayerPrefs.GetString("Language"));
            }
            else
            {
                lang = new Lang((TextAsset)Resources.Load("System"), "Finnish");
            }
        }
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.title:
                break;
            case GameState.playing:
                UpdatePlaying();
                break;
            case GameState.cutScene:
                UpdateCutScene();
                break;
            case GameState.gameover:
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.F1)){
            GoToCutScene();
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            GotoPlaymode();
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            GoToGameOver();
        }
    }

    private void UpdatePlaying()
    {
        playController.UpdatePlayMode();
    }

    private void UpdateCutScene()
    {
        cutsceneController.UpdateCutscene();
    }

    public void GotoTitleScreen()
    {
        gameState = GameState.title;
        SwitchMode();
    }

    public void GoToCutScene()
    {
        gameState = GameState.cutScene;
        SwitchMode();
    }

    public void GotoPlaymode()
    {
        gameState = GameState.playing;
        SwitchMode();
    }

    public void GoToGameOver()
    {
        gameState = GameState.gameover;
        SwitchMode();
    }

    public void ToggelWaitForAnimation(bool wait)
    {
        cutsceneController.ToggelWaitForAnimation(wait);
    }

    void SwitchMode()
    {
        if (canvasTitle != null)
        {
            canvasTitle.SetActive(false);
        }
        canvasGame.SetActive(false);
        canvasText.SetActive(false);
        canvasEnd.SetActive(false);

        PlayerController.Instance.ToggleControl(false);

        switch (gameState)
        {
            case GameState.title:
                canvasTitle.SetActive(true);
                break;
            case GameState.playing:
                canvasGame.SetActive(true);
                playController.Reset();
                Score.Instance.UpdateScoreText();
                PlayerController.Instance.ToggleControl(true);
                playController.ActivateSpawn();
                break;
            case GameState.cutScene:
                canvasText.SetActive(true);
                cutsceneController.RestartDialogue();
                break;
            case GameState.gameover:
                canvasEnd.SetActive(true);
                canvasEnd.GetComponentInChildren<Text>().text = Score.Instance.GetGradeText();
                break;
            default:
                break;
        }
    }
}
