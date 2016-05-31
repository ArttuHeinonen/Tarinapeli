using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour {

    public Text text;
    public GameObject textPanel;

    private Lang sceneText;
    public List<string> dialogs;
    private string fileName;
    public int currentLine = 0;
    public int lastLine;
    public bool isFinished;

	void Start () {
        dialogs = new List<string>();
        StartOver();
	}

    public void HideDialog()
    {
        text.text = "";
        textPanel.SetActive(false);
    }

    public void ShowCurrentLine()
    {
        text.text = dialogs[currentLine];
        textPanel.SetActive(true);
    }

    public void ShowNextLine()
    {
        if(!IsCurrentLineOverLastLine())
        {
            currentLine++;
            ShowCurrentLine();
        }
        textPanel.SetActive(true);
    }

    public void MoveToNextLine()
    {
        if (!IsCurrentLineOverLastLine())
        {
            currentLine++;
            if(currentLine >= lastLine)
            {
                isFinished = true;
            }
        }
        textPanel.SetActive(true);
    }

    private bool IsCurrentLineOverLastLine()
    {
        if (currentLine >= lastLine)
        {
            HideDialog();
            currentLine = lastLine;
            isFinished = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StartOver()
    {
        currentLine = 0;
        isFinished = false;
        dialogs.Clear();
        
        LoadDialog();
        if (lastLine == 0)
        {
            lastLine = dialogs.Count - 1;
        }
    }

    public void LoadDialog()
    {
        dialogs.Clear();
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                fileName = "scene1";
                break;
            case "UnderwaterScene":
                fileName = "scene2";
                break;
            default:
                break;
        }
        sceneText = new Lang((TextAsset)Resources.Load(fileName), GameController.Instance.lang.getLanguage());
        FillDialogs();
    }

    void FillDialogs()
    {
        foreach (string line in sceneText.getAllStrings())
        {
            dialogs.Add(line);
        }
    }
}
