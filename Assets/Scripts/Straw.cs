using UnityEngine;
using System.Collections;

public class Straw : MonoBehaviour {

	public static Straw Instance = null;

    private Animator anim;
    public AudioClip suck;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        anim = GetComponentInChildren<Animator>();
    }

    public void PlaySuckingSound()
    {
        SoundManager.Instance.PlaySingle(suck);
    }

    public void AnimateSucking()
    {
        anim.SetTrigger("Suck");
    }

    public void ResetAnimationBools()
    {

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
