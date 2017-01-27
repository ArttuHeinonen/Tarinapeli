using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceGameController : MonoBehaviour {

    public static SpaceGameController Instance;

    public enum GameState { playing, cutScene, gameover };
    public GameState gameState;

    public bool debug = true;
    private Camera cam;
    public GameObject canvasText;
    public GameObject canvasGame;
    public GameObject canvasEnd;
    public GameObject canvasEndButtons;
    private SpaceCutscene cutsceneController;
    private SpacePlayController playController;
    private SpaceGameOverController gameOverController;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (cam == null)
        {
            cam = Camera.main;
        }
        playController = GetComponent<SpacePlayController>();
        cutsceneController = GetComponent<SpaceCutscene>();
        gameOverController = GetComponent<SpaceGameOverController>();
        InitLanguage();
        GoToCutScene();
    }

    void InitLanguage()
    {
        if (Object.ReferenceEquals(null, LangController.Instance))
        {
            LangController.Instance = new LangController();
        }
        if (LangController.Instance.GetSysLang() == null)
        {
            if (PlayerPrefs.HasKey("Language"))
            {
                LangController.Instance.InitSystemLang(PlayerPrefs.GetString("Language"));
            }
            else
            {
                LangController.Instance.InitSystemLang("English");
            }
        }
    }

    void Update()
    {
        switch (gameState)
        {
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
        canvasGame.SetActive(false);
        canvasText.SetActive(false);
        canvasEnd.SetActive(false);
        canvasEndButtons.SetActive(false);

        SpacePlayerController.Instance.ToggleControl(false);

        switch (gameState)
        {
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
        if (cutsceneController.dialogController.currentLine >= cutsceneController.dialogController.lastLine)
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
