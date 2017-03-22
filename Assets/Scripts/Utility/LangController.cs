using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System;

public class Lang
{
    private Hashtable Strings;
    private List<string> StringList;
    private String currentLanguage;
    private XmlDocument xml;

    public Lang(string path, string language)
    {
        LoadByPath(path, language);
    }

    public Lang(TextAsset file, string language)
    {
        LoadByAsset(file, language);
    }

    public void LoadByPath(string path, string language)
    {
        xml = new XmlDocument();
        xml.Load(path);
        setLanguage(language);
    }

    public void LoadByAsset(TextAsset file, string language)
    {
        xml = new XmlDocument();
        xml.LoadXml(file.text);
        setLanguage(language);
    }

    void setLanguage(string language)
    {
        Strings = new Hashtable();
        var element = xml.DocumentElement[language];
        if (element != null)
        {
            StringList = new List<string>();
            StringList.Clear();
            currentLanguage = language;
            var elemEnum = element.GetEnumerator();
            while (elemEnum.MoveNext())
            {
                var xmlItem = (XmlElement)elemEnum.Current;
                StringList.Add(xmlItem.InnerText);
                Strings.Add(xmlItem.GetAttribute("name"), xmlItem.InnerText);
            }
            PlayerPrefs.SetString("Language", currentLanguage);
        }
        else
        {
            Debug.LogError("The " + language + " language does not exist.");
        }
    }

    public string GetString(string name)
    {
        if (!Strings.ContainsKey(name))
        {
            Debug.LogError("The specified string does not exist: " + name);
            return "";
        }
        return (string)Strings[name];
    }


    public string GetLanguage()
    {
        return this.currentLanguage;
    }

    public List<string> GetAllStrings()
    {
        return StringList;
    }
}

public class LangController : MonoBehaviour {

    public static LangController Instance = null;
    private Lang sysLang;
    private Lang sceneLang;
    private Lang scoreLang;

    void Start()
    {
        GetInstance();
    }

    public LangController GetInstance()
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
        return Instance;
    }

    public void InitSystemLang(string lang)
    {
        sysLang = new Lang((TextAsset)Resources.Load("System"), lang);
    }

    public void InitSceneLang(string fileName, string lang)
    {
        sceneLang = new Lang((TextAsset)Resources.Load(fileName), lang);
    }

    public void InitScoreLang(string lang)
    {
        scoreLang = new Lang((TextAsset)Resources.Load("Score"), lang);
    }

    public Lang GetSysLang()
    {
        return this.sysLang;
    }

    public string GetSysLangString()
    {
        return this.sysLang.GetLanguage();
    }

    public void SetSysLang(Lang setterLang)
    {
        sysLang = setterLang;
    }

    public Lang GetSceneLang()
    {
        return this.sceneLang;
    }

    public Lang GetScoreLang()
    {
        return this.scoreLang;
    }
}
