using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour {

    public DialogueController dialogController;
    public bool waitForAnimation;

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
            }
            else
            {
                dialogController.ShowCurrentLine();
            }
        }
    }

    void UpdateMelon()
    {
        switch (dialogController.currentLine)
        {
            case 0:
                OwlController.Instance.AnimateFly();
                waitForAnimation = true;
                dialogController.MoveToNextLine();
                break;
            case 1:
                PlayerController.Instance.Animate("Search");
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
            GameController.Instance.GotoPlaymode();
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

    public void SkipAnimations()
    {
        if (waitForAnimation)
        {
            StartCoroutine(OwlController.Instance.SkipAnimation());
            StartCoroutine(PlayerController.Instance.SkipAnimation());
            if(GrannyController.Instance != null)
            {
                StartCoroutine(GrannyController.Instance.SkipAnimation());
            }
        }
    }

    public void ActivateMusic()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                SoundManager.Instance.PlayBirdMusic();
                break;
            case "UnderwaterScene":
                SoundManager.Instance.PlayBirdMusic();
                break;
            default:
                break;
        }
    }

    public void SetupScene()
    {
        dialogController.LoadDialog();
        ActivateMusic();

        switch (SceneManager.GetActiveScene().name)
        {
            case "MelonScene":
                break;
            case "UnderwaterScene":
                PlayerController.Instance.ChangeSpriteToHungry();
                break;
            default:
                break;
        }
    }
}
