using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public bool isCanvasShowing = false;
    public Canvas sceneCanvas;
    public Canvas infoCanvas;
    public Canvas langCanvas;

    public Lang sysLang;

    public Text startButtonText;
    public Text chooseStoryText;
    public Text chooseLangText;
    public Text creditsText;

    public void Start()
    {
        sceneCanvas.enabled = false;
        infoCanvas.enabled = false;
        langCanvas.enabled = false;
        InitLanguage();
        UpdateUIElements();
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
        GameController.Instance.GoToCutScene();
    }

    public void PlayClickAudio()
    {
        SoundManager.Instance.PlayClick();
    }

    public void ShowSelectSceneCanvas()
    {
        if (!isCanvasShowing)
        {
            isCanvasShowing = true;
            sceneCanvas.enabled = true;
        }
        PlayClickAudio();
    }

    public void ShowInfoCanvas()
    {
        if (!isCanvasShowing)
        {
            isCanvasShowing = true;
            infoCanvas.enabled = true;
        }
        PlayClickAudio();
    }

    public void ShowLangCanvas()
    {
        if (!isCanvasShowing)
        {
            isCanvasShowing = true;
            langCanvas.enabled = true;
        }
        PlayClickAudio();
    }

    public void HideCanvas()
    {
        if (isCanvasShowing)
        {
            isCanvasShowing = false;
            sceneCanvas.enabled = false;
            infoCanvas.enabled = false;
            langCanvas.enabled = false;
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
                GameController.Instance.GoToCutScene();
                break;
            case "Underwater":
                SceneManager.LoadScene("UnderwaterScene");
                break;
            case "Space":
                SceneManager.LoadScene("SpaceScene");
                break;
            default:
                break;
        }
    }
}
