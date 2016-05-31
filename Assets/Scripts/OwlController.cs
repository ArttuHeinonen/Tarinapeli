using System.Collections;
using UnityEngine;

public class OwlController : MonoBehaviour {

    public static OwlController Instance { get; private set; }

    private Animator anim;
    public bool flying;
    public float animationDuration = 5f;
    public AudioClip splash;

	void Start () {
        Instance = this;
        anim = GetComponentInChildren<Animator>();
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
        SoundManager.Instance.PlaySingle(splash);
    }

    public IEnumerator SkipAnimation()
    {
        anim.speed = 99999;
        yield return new WaitForSeconds(0.2f);
        anim.speed = 1;
    }
}
