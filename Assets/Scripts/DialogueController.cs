using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

    public Text text;

    public TextAsset textFile;
    public string[] dialogs;
    public int currentLine = 0;
    public int lastLine;
    public bool isFinished;

	// Use this for initialization
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
    }

    public void ShowCurrentLine()
    {
        text.text = dialogs[currentLine];
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
        
    }

    private void FillDialogs()
    {
        if(textFile != null)
        {
            dialogs = textFile.text.Split('\n');
        }
    }
}
