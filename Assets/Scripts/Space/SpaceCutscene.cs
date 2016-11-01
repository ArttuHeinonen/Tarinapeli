using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpaceCutscene : MonoBehaviour {

    public DialogueController dialogController;
    public bool waitForAnimation;

    void Start () {
        waitForAnimation = false;
    }

    public void UpdateCutscene()
    {

        if (!waitForAnimation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (dialogController.currentLine)
                {
                    case 0:
                        //SpaceOwl.Fly();
                        waitForAnimation = true;
                        dialogController.MoveToNextLine();
                        break;
                    case 1:
                        waitForAnimation = true;
                        dialogController.MoveToNextLine();
                        break;
                    case 2:
                        GameController.Instance.GotoPlaymode();
                        break;
                    case 3:
                        GameController.Instance.ToggleEndGameButtons(true);
                        break;
                    default:
                        dialogController.ShowNextLine();
                        break;
                }
            }
            else
            {
                dialogController.ShowCurrentLine();
            }
        }
    }

    public void ActivateMusic()
    {
        
    }

    public void ToggelWaitForAnimation(bool wait)
    {
        this.waitForAnimation = wait;
    }

    public void SetupScene()
    {
        dialogController.LoadDialog();
        ActivateMusic();
    }
}
