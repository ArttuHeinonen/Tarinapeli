using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MelonCutscene : Cutscene
{

    public override void SetupScene()
    {
        dialog.LoadDialog();
        waitForAnimation = false;

    }

    public override void SkipAnimation()
    {
        if (waitForAnimation)
        {
            //StartCourutine(everyAnimator holder in scene.)
        }
    }

    public override void UpdateCutscene()
    {
        if (!waitForAnimation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (dialog.currentLine)
                {
                    case 0:
                        dialog.MoveToNextLine();
                        break;
                    case 1:
                        dialog.MoveToNextLine();
                        break;
                    case 2:
                        GameController.Instance.GotoPlaymode();
                        break;
                    default:
                        break;
                }
            }
            dialog.ShowCurrentLine();
        }
        
    }
}
