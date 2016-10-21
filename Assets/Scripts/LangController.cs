using UnityEngine;
using System.Collections;

public class LangController : MonoBehaviour {

    public static LangController Instance = null;
    private Lang sysLang;
    private Lang sceneLang;

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
        DontDestroyOnLoad(gameObject);
    }

    public void InitSystemLang(string lang)
    {
        sysLang = new Lang((TextAsset)Resources.Load("System"), lang);
    }

    public void InitSceneLang(string fileName, string lang)
    {
        sceneLang = new Lang((TextAsset)Resources.Load(fileName), lang);
    }

    public Lang GetSysLang()
    {
        return this.sysLang;
    }

    public string GetSysLangString()
    {
        return this.sysLang.getLanguage();
    }

    public void SetSysLang(Lang setterLang)
    {
        sysLang = setterLang;
    }

    public Lang GetSceneLang()
    {
        return this.sceneLang;
    }

}
