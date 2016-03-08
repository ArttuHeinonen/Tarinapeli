using UnityEngine;
using System.Collections;

public class OwlController : MonoBehaviour {

    public static OwlController Instance { get; private set; }

    private Animator anim;
    public bool flying;
    public float animationDuration = 5f;
    public AudioClip splash;
    private AudioSource source;

	void Start () {
        Instance = this;
        anim = GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
    }
	
    public void AnimateFly()
    {
        anim.SetTrigger("OwlFly");
        flying = true;
    }

    public void AnimateSubmarinePeek()
    {
        anim.SetTrigger("SubmarinePeek");
    }

    public void AnimateSubmarineMove()
    {
        anim.SetTrigger("SubmarineMove");
    }

    public void PlaySplashSound()
    {
        source.PlayOneShot(splash);
    }

}
