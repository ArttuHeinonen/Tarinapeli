using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneController : MonoBehaviour {

    public AudioClip clickAudio;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void RestartPlaySection()
    {
        PlayClickAudio();
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                PlayerController.Instance.ChangespriteToDefault();
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
        PlayerController.Instance.ChangespriteToDefault();
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
        //SceneManager.LoadScene("HomeScene");
    }

    public void GoToCutscene()
    {
        GameController.Instance.GoToCutScene();
    }

    public void PlayClickAudio()
    {
        audioSource.PlayOneShot(clickAudio);
    }

    public void ChangeLanguagesToFinnish()
    {
        PlayClickAudio();
        GameController.Instance.lang.LoadByAsset((TextAsset)Resources.Load("System"), "Finnish");
    }

    public void ChangeLanguagesToEnglish()
    {
        PlayClickAudio();
        GameController.Instance.lang.LoadByAsset((TextAsset)Resources.Load("System"), "English");
    }
}
