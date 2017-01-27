using UnityEngine;
using System.Collections;

public class SpacePlayerController : MonoBehaviour {

    public static SpacePlayerController Instance { get; private set; }
    private Animator anim;
    private Camera cam;
    private bool canControl = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }
        canControl = false;
        anim = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        if (canControl)
        {

        }
    }


    public void ToggleControl(bool toggle)
    {
        canControl = toggle;
    }

    public void Animate(string animationName)
    {
        anim.SetTrigger(animationName);
    }

}
