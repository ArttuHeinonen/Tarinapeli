using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

    public void StartAnimation()
    {
        GameController.Instance.ToggelWaitForAnimation(true);
    }

    public void EndAnimation()
    {
        GameController.Instance.ToggelWaitForAnimation(false);
    }
}
