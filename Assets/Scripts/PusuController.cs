using UnityEngine;
using System.Collections;

public class PusuController : MonoBehaviour {

	public static PusuController Instance { get; private set; }

    private Animator anim;

	void Start () {
        Instance = this;
        anim = GetComponentInChildren<Animator>();
	}

    public void Animate(string animation)
    {
        anim.SetTrigger(animation);
    }

    public void ChangeSpriteToThinkBubble()
    {
        anim.SetBool("ThinkBubble", true);
    }

    public void ResetAnimationBools()
    {
        anim.SetBool("ThinkBubble", false);
    }
}
