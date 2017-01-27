using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceScore : MonoBehaviour {

    public static SpaceScore Instance;
    public Text scoreText;
    public Lang scoreLang;
    public float grade;
    public int stars = 0;
    public int lives = 3;
    public int maxLives = 3;


    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        lives = 3;
    }

    void InitLanguage()
    {
        if (LangController.Instance.GetSysLang() != null)
        {
            string language = LangController.Instance.GetSysLangString();
            LangController.Instance.InitSceneLang("score", language);
        }
        else
        {
            LangController.Instance.InitSceneLang("score", "English");
        }
        scoreLang = LangController.Instance.GetSceneLang();
    }

    public void ResetScores()
    {

    }
}
