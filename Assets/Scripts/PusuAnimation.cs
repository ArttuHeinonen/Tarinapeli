using UnityEngine;
using System.Collections;

public class PusuAnimation : MonoBehaviour {

	public void ReachOo()
    {
        PlayerController.Instance.ChangeSpriteToHug();
    }

    public void StartThinking()
    {
        PusuController.Instance.ChangeSpriteToThinkBubble();
    }
    public void StopThinking()
    {
        GameController.Instance.ToggelWaitForAnimation(false);
    }
}
