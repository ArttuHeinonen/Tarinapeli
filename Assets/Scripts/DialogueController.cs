using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueController : MonoBehaviour {

    public static DialogueController Instance { get; private set; }

    public TextAsset textFile;
    public string[] dialogs;

	// Use this for initialization
	void Start () {
        Instance = this;
        FillDialogs();
	}
	
    public void FillDialogs()
    {
        if(textFile != null)
        {
            dialogs = textFile.text.Split('\n');
        }
    }
}
