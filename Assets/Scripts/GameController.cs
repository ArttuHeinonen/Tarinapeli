using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    public GameObject canvasEndButtons;
    private CutsceneController cutsceneController;
    private PlayController playController;
    private GameOverController gameOverController;
    public Lang lang;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Instance = this;
        if(cam == null)
        {
            cam = Camera.main;
        }
        playController = GetComponent<PlayController>();
        cutsceneController = GetComponent<CutsceneController>();
        gameOverController = GetComponent<GameOverController>();
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
                UpdateGameOver();
                break;
            default:
                break;
        }
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                cutsceneController.dialogController.StartOver();
                GoToCutScene();
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                GotoPlaymode();
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                cutsceneController.dialogController.currentLine = 2;
                GoToGameOver();
            }
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

    private void UpdateGameOver()
    {
        gameOverController.UpdateGameOver();
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

    public void ToggleEndGameButtons(bool visible)
    {
        canvasEndButtons.SetActive(visible);
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
        canvasEndButtons.SetActive(false);

        PlayerController.Instance.ToggleControl(false);

        switch (gameState)
        {
            case GameState.title:
                cutsceneController.SkipAnimations();
                cutsceneController.RestartDialogue();
                canvasTitle.SetActive(true);
                SoundManager.Instance.PlayTitleMusic();
                break;
            case GameState.playing:
                canvasGame.SetActive(true);
                playController.Reset();
                Score.Instance.UpdateScoreText();
                PlayerController.Instance.ToggleControl(true);
                playController.ActivateSpawn();
                playController.ActivateMusic();
                break;
            case GameState.cutScene:
                cutsceneController.SetupScene();
                canvasText.SetActive(true);
                break;
            case GameState.gameover:
                canvasEnd.SetActive(true);
                canvasEnd.GetComponentInChildren<Text>().text = Score.Instance.GetGradeText();
                break;
            default:
                break;
        }
    }

    public bool IsDialogFinished()
    {
        return cutsceneController.dialogController.isFinished;
    }

    public void SetCurrentLine(int line)
    {
        cutsceneController.dialogController.currentLine = line;
        if(cutsceneController.dialogController.currentLine >= cutsceneController.dialogController.lastLine)
        {
            cutsceneController.dialogController.isFinished = true;
        }
        else
        {
            cutsceneController.dialogController.isFinished = false;
        }
    }

    public void MoveNextDialog()
    {
        cutsceneController.dialogController.MoveToNextLine();
    }

    public void HideDialog()
    {
        cutsceneController.dialogController.HideDialog();
    }

    public void ShowDialog()
    {
        cutsceneController.dialogController.ShowCurrentLine();
    }
}
