using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public bool isCanvasShowing = false;
    public GameObject scenePanel;
    public GameObject infoPanel;
    public GameObject langPanel;
    public GameObject settingsPanel;

    public Lang sysLang;

    public Text startButtonText;
    public Text chooseStoryText;
    public Text chooseLangText;
    public Text creditsText;
    public Text eraseDataText;

    public AudioManager audioManager;
    public string buttonClick = "Button_Click";

    void Start()
    {
        scenePanel.SetActive(false);
        infoPanel.SetActive(false);
        langPanel.SetActive(false);
        settingsPanel.SetActive(false);
        InitLanguage();
        UpdateUIElements();
        audioManager = AudioManager.Instance;
        if(audioManager == null)
        {
            Debug.Log("Audiomanager not found!");
        }
    }

    void InitLanguage()
    {
        if (sysLang == null)
        {
            if (PlayerPrefs.HasKey("Language"))
            {
                sysLang = new Lang((TextAsset)Resources.Load("System"), PlayerPrefs.GetString("Language"));
            }
            else
            {
                sysLang = new Lang((TextAsset)Resources.Load("System"), "English");
            }
        }
    }

    public void StartTheGame()
    {
        PlayClickAudio();
        SceneManager.LoadScene("Melon");
    }

    public void PlayClickAudio()
    {
        audioManager.PlaySound(buttonClick);
    }

    public void ShowSelectSceneCanvas()
    {
        PlayClickAudio();
        SceneManager.LoadScene("Overworld");
    }

    public void ShowInfoCanvas()
    {
        if (!isCanvasShowing)
        {
            isCanvasShowing = true;
            infoPanel.SetActive(true);
        }
        PlayClickAudio();
    }

    public void ShowLangCanvas()
    {
        if (!isCanvasShowing)
        {
            isCanvasShowing = true;
            langPanel.SetActive(true);
        }
        PlayClickAudio();
    }

    public void ShowSettingsPanel()
    {
        if (!isCanvasShowing)
        {
            isCanvasShowing = true;
            settingsPanel.SetActive(true);
        }
        PlayClickAudio();
    }

    public void HideCanvas()
    {
        if (isCanvasShowing)
        {
            isCanvasShowing = false;
            scenePanel.SetActive(false);
            infoPanel.SetActive(false);
            langPanel.SetActive(false);
            settingsPanel.SetActive(false);
        }
        PlayClickAudio();
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/HiHappening/");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/Hihappening");
    }

    public void OpenYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCJoMZiSyIrSSQazee1SKtqg");
    }

    public void OpenTumblr()
    {
        Application.OpenURL("http://ooslifethegame.tumblr.com/");
    }

    public void ChangeLanguage(string lang)
    {
        sysLang.LoadByAsset((TextAsset)Resources.Load("System"), lang);
        UpdateUIElements();
        LangController.Instance.SetSysLang(this.sysLang);
        HideCanvas();
    }

    void UpdateUIElements()
    {
        startButtonText.text = sysLang.getString("startButton");
        chooseStoryText.text = sysLang.getString("chooseStory");
        chooseLangText.text = sysLang.getString("chooseLang");
        creditsText.text = sysLang.getString("credits");
    }

    public void StartScene(string scene)
    {
        HideCanvas();
        switch (scene)
        {
            case "Melon":
                //GameController.Instance.GoToCutScene();
                break;
            case "Underwater":
                //SceneManager.LoadScene("Underwater");
                break;
            case "Space":
                //SceneManager.LoadScene("Space");
                break;
            default:
                break;
        }
    }

    public void EraseData()
    {
        DataManager.Instance.DeleteData();
        DataManager.Instance.CreateData();
    }
}
