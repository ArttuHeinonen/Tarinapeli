using UnityEngine;
using System.Collections;

public class GrannyController : MonoBehaviour {

    public static GrannyController Instance { get; private set; }

    private Animator anim;
    public AudioClip scream;

	void Start () {
        Instance = this;
        anim = GetComponentInChildren<Animator>();
    }
	
    public void PlayScreamSound()
    {
        SoundManager.Instance.PlaySingle(scream);
    }

    public void AnimateFalling()
    {
        anim.SetTrigger("GrannyFall");
        anim.SetBool("Idle", false);
        PlayScreamSound();
    }

    public void ResetAnimationBools()
    {
        anim.SetBool("Idle", true);
    }

    public void PauseAnimation()
    {
        anim.Stop();
    }

    public IEnumerator SkipAnimation()
    {
        anim.speed = 99999;
        yield return new WaitForSeconds(0.2f);
        anim.speed = 1;
    }
}
