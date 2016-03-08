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
        if(currentLine >= lastLine)
        {
            HideDialog();
            isFinished = true;
        }
        else
        {
            currentLine++;
            ShowCurrentLine();
        }
        textPanel.SetActive(true);
    }

    public void MoveToNextLine()
    {
        if (currentLine >= lastLine)
        {
            HideDialog();
            isFinished = true;
        }
        else
        {
            currentLine++;
        }
        textPanel.SetActive(true);
    }

    public void StartOver()
    {
        currentLine = 0;
        isFinished = false;
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
        //sceneText = new Lang(fileName, GameController.Instance.lang.getLanguage());
        FillDialogs();
        if (lastLine == 0)
        {
            lastLine = dialogs.Count - 1;
        }
    }

    void FillDialogs()
    {
        foreach (string line in sceneText.getAllStrings())
        {
            dialogs.Add(line);
        }
    }
}
