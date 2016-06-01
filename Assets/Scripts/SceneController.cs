using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneController : MonoBehaviour {

    public void RestartPlaySection()
    {
        PlayClickAudio();
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                PlayerController.Instance.ChangeSpriteToDefault();
                GrannyController.Instance.ResetAnimationBools();
                GameController.Instance.SetCurrentLine(2);
                break;
            case "UnderwaterScene":
                PlayerController.Instance.ChangeSpriteToUnderWater();
                break;
            default:
                break;
        }
        GameController.Instance.GotoPlaymode();
    }

    public void NextLevel()
    {
        PlayClickAudio();
        PlayerController.Instance.ChangeSpriteToDefault();
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                SceneManager.LoadScene("UnderwaterScene");
                break;
            case "UnderwaterScene":
                SceneManager.LoadScene("MelonScene");
                break;
            default:
                break;
        }
    }

    public void GoHome()
    {
        PlayClickAudio();
        PlayerController.Instance.ChangeSpriteToDefault();
        OwlController.Instance.SkipAnimation();
        if (SceneManager.GetActiveScene().name == "MelonScene")
        {
            GrannyController.Instance.ResetAnimationBools();
        }
        else
        {
            SceneManager.LoadScene("MelonScene");
        }
        GameController.Instance.GotoTitleScreen();
    }

    public void GoToCutscene()
    {
        PlayClickAudio();
        GameController.Instance.GoToCutScene();
    }

    public void PlayClickAudio()
    {
        SoundManager.Instance.PlayClick();
    }

    public void ChangeLanguageToFinnish()
    {
        PlayClickAudio();
        GameController.Instance.lang.LoadByAsset((TextAsset)Resources.Load("System"), "Finnish");
        GoToCutscene();
    }

    public void ChangeLanguageToEnglish()
    {
        PlayClickAudio();
        GameController.Instance.lang.LoadByAsset((TextAsset)Resources.Load("System"), "English");
        GoToCutscene();
    }
}
