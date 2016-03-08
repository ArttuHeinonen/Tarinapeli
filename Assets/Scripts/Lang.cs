using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

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
            Debug.LogError("The "+ language +" language does not exist.");
        }
    }

    public string getString(string name)
    {
        if (!Strings.ContainsKey(name))
        {
            Debug.LogError("The specified string does not exist: " + name);
            return "";
        }

        return (string)Strings[name];
    }


    public string getLanguage()
    {
        return this.currentLanguage;
    }

    public List<string> getAllStrings()
    {
        return StringList;
    }
}