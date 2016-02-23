using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

    public Text text;
    public GameObject textPanel;

    public TextAsset textFile;
    public string[] dialogs;
    public int currentLine = 0;
    public int lastLine;
    public bool isFinished;

	void Start () {
        FillDialogs();
        isFinished = false;
        if(lastLine == 0)
        {
            lastLine = dialogs.Length - 1;
        }
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

    private void FillDialogs()
    {
        if(textFile != null)
        {
            dialogs = textFile.text.Split('\n');
        }
    }
}
