using UnityEngine;
using System.Collections;

public class OwlController : MonoBehaviour {

    public static OwlController Instance { get; private set; }

    private Animator anim;

	void Start () {
        Instance = this;
        anim = GetComponentInChildren<Animator>();
    }
	
    public void AnimateFly()
    {
        anim.SetTrigger("OwlFly");
    }

}
