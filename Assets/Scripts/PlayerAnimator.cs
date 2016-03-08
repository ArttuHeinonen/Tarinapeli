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
        ScreenController.Instance.SwapToAltBackground();
        ScreenController.Instance.HideChild();
        PlayerController.Instance.PlaySplashAudio();
        PlayerController.Instance.ChangeSpriteToUnderWater();
        OwlController.Instance.AnimateSubmarineMove();
        PlayerController.Instance.Animate("FallInWater");
    }

    public void FallInWater()
    {
        PusuController.Instance.Animate("StartThinking");
    }
}
