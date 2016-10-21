using UnityEngine;
using System.Collections;

public class SpaceOwlController : MonoBehaviour {

    public static OwlController Instance { get; private set; }

    private Animator anim;
    public bool flying;
    public float animationDuration = 5f;
    public AudioClip splash;

    void Start () {
	    
	}
	

	void Update () {
	
	}
}
