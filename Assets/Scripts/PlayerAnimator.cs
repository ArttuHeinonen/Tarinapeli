using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

    public void StartWaitForAnimation()
    {
        GameController.Instance.ToggelWaitForAnimation(true);
    }

    public void EndWaitForAnimation()
    {
        GameController.Instance.ToggelWaitForAnimation(false);
    }

    public void StartFreezing()
    { 
        PlayerController.Instance.FreezeControls(1.2f);
    }

    public void JumpToWater()
    {
        ScreenController.Instance.SwapToNextBackground();
        ScreenController.Instance.HideChild();
        GameController.Instance.HideDialog();
        PlayerController.Instance.PlaySplashAudio();
        PlayerController.Instance.ChangeSpriteToUnderWater();
        OwlController.Instance.AnimateSubmarineMove();
        SoundManager.Instance.StopPlayingMusic();
        PlayerController.Instance.Animate("FallInWater");
    }

    public void FallInWater()
    {
        GameController.Instance.ShowDialog();
        PusuController.Instance.Animate("StartThinking");
    }
}
