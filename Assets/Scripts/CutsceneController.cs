using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour {

    public DialogueController dialogController;
    private bool waitForAnimation;

    void Start () {

        waitForAnimation = false;
    }
	
	public void UpdateCutscene () {

        if (!waitForAnimation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (SceneManager.GetActiveScene().name)
                {
                    case "MelonScene":
                        UpdateMelon();
                        break;
                    case "UnderwaterScene":
                        UpdateUnderWater();
                        break;
                    default:
                        break;
                }

                if (dialogController.isFinished)
                {
                    GameController.Instance.GotoPlaymode();
                }
            }
            else
            {
                dialogController.ShowCurrentLine();
            }
        }

    }

    void UpdateMelon()
    {
        if (dialogController.currentLine == 0)
        {
            OwlController.Instance.AnimateFly();
            waitForAnimation = true;
            dialogController.MoveToNextLine();
        }
        else if (dialogController.currentLine == 1)
        {
            PlayerController.Instance.Animate("Search");
            waitForAnimation = true;
            dialogController.MoveToNextLine();
        }
        else
        {
            dialogController.ShowNextLine();
        }
    }

    void UpdateUnderWater()
    {
        if (dialogController.currentLine == 0)
        {
            OwlController.Instance.AnimateSubmarinePeek();
            waitForAnimation = true;
            dialogController.MoveToNextLine();
        }
        else if (dialogController.currentLine == 1)
        {
            PusuController.Instance.ResetAnimationBools();
            dialogController.MoveToNextLine();
        }
        else
        {
            dialogController.ShowNextLine();
        }
    }

    public void ToggelWaitForAnimation(bool wait)
    {
        this.waitForAnimation = wait;
    }

    public void RestartDialogue()
    {
        dialogController.StartOver();
        if (SceneManager.GetActiveScene().name == "UnderwaterScene")
        {
            PlayerController.Instance.ChangeSpriteToHungry();
            PlayerController.Instance.PutPlayerNearBond();
        }
    }
}
