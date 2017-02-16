using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutscene : Cutscene
{

    public override void SetupScene()
    {
        dialog.LoadDialog();
        //Starts with Oo gazing away from books animation
        //For testing purposes no animations are added
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
                        DataManager.Instance.CreateData();
                        SceneManager.LoadScene("Main");
                        break;
                    default:
                        break;
                }
            }
            dialog.ShowCurrentLine();
        }
        
    }
}
