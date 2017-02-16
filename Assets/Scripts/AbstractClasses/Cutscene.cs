using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Cutscene : MonoBehaviour {

    public DialogueController dialog;
    public bool waitForAnimation;

    void Start()
    {
        waitForAnimation = false;
    }

    public abstract void UpdateCutscene();
    public abstract void SkipAnimation();
    public abstract void SetupScene();

    public void ToggleWaitForAnimation(bool wait)
    {
        waitForAnimation = false;
    }

    public void RestartDialogue()
    {
        dialog.StartOver();
    }

    /// <summary>
    /// Activates Cutscene music based on scene name.
    /// </summary>
    /// <example>
    /// Melon (scene) -> PlaySound(MelonMusic)
    /// </example>
    public void ActivateMusic()
    {
        AudioManager.Instance.PlaySound(SceneManager.GetActiveScene().name + "Music");
    }


}
