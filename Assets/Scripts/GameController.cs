using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;
    public GameState gameState;

    public bool debug = true;
    private Camera cam;
    public GameObject cutscenePanel;
    public GameObject playPanel;
    public GameObject gameoverPanel;
    public Cutscene cutscene;
    public Play play;
    public GameOver gameOver;

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
                play.UpdatePlay();
                break;
            case GameState.cutScene:
                cutscene.UpdateCutscene();
                break;
            case GameState.gameover:
                gameOver.UpdateGameOver();
                break;
        }
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                cutscene.dialog.StartOver();
                GoToCutScene();
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                GotoPlaymode();
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                cutscene.dialog.SkipToLastLine();
                GoToGameOver();
            }
        }
    }

    public void GotoTitleScreen()
    {
        SceneManager.LoadScene("Main");
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

    void SwitchMode()
    {
        playPanel.SetActive(false);
        cutscenePanel.SetActive(false);
        gameoverPanel.SetActive(false);

        play.canControl = false;

        switch (gameState)
        {
            case GameState.playing:
                playPanel.SetActive(true);
                play.ResetValues();
                play.canControl = true;
                play.ActivateSpawn();
                play.ActivateMusic();
                break;
            case GameState.cutScene:
                cutscene.SetupScene();
                cutscenePanel.SetActive(true);
                break;
            case GameState.gameover:
                gameoverPanel.SetActive(true);
                gameoverPanel.GetComponentInChildren<Text>().text = play.score.GetGradeText();
                break;
            default:
                break;
        }
    }

    public bool IsDialogFinished()
    {
        return cutscene.dialog.isFinished;
    }

    public void SetCurrentLine(int line)
    {
        cutscene.dialog.currentLine = line;
        if (cutscene.dialog.currentLine >= cutscene.dialog.lastLine)
        {
            cutscene.dialog.isFinished = true;
        }
        else
        {
            cutscene.dialog.isFinished = false;
        }
    }

    public void MoveNextDialog()
    {
        cutscene.dialog.MoveToNextLine();
    }

    public void HideDialog()
    {
        cutscene.dialog.HideDialog();
    }

    public void ShowDialog()
    {
        cutscene.dialog.ShowCurrentLine();
    }
}
