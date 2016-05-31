using UnityEngine;
using System.Collections;

public class OwlAnimation : MonoBehaviour {

	public void PlaySplashSound()
    {
        OwlController.Instance.PlaySplashSound();
    }

    public void StopPeekAnimation()
    {
        PlayerController.Instance.Animate("JumpToWater");
    }

    public void StopFlyAnimation()
    {
        OwlController.Instance.flying = false;
        GameController.Instance.ToggelWaitForAnimation(false);
    }

    public void HitOoWhileFlying()
    {
        PlayerController.Instance.ChangeSpriteToHungry();
        SoundManager.Instance.PlayBoing();
    }

    public void OoRecoversFromHit()
    {
        PlayerController.Instance.ChangeSpriteToDefault();
    }
}
