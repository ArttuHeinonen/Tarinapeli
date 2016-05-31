using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance { get; private set; }

    private Camera cam;
    private float maxWidth;
    private float maxHeigh;
    private bool canControl = false;
    private float controlCooldown = 0;
    private Animator anim;
    private float jump = 10f;
    public float jumpVelocity;
    private float gravity = 0.2f;

    public AudioClip swimAudio;
    public AudioClip splashAudio;

    void Awake()
    {
        Instance = this;
    }
    void Start () {
        
	    if(cam == null)
        {
            cam = Camera.main;
        }
        canControl = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 target = cam.ScreenToWorldPoint(upperCorner);
        maxWidth = target.x;
        maxHeigh = target.y;
        anim = GetComponentInChildren<Animator>();
    }

	public void MelonUpdate () {
        if (canControl)
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPosition = new Vector3(rawPosition.x, 0f, 0f);
            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            transform.position = new Vector3(targetWidth, transform.position.y);
        }
        else
        {
            ReduceCooldown();
        }
	}

    public void UnderWaterUpdate()
    {
        if (canControl)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Animate("Swim");
                PlaySwimAudio();
                FreezeControls(0.25f);
                jumpVelocity += jump;
            }  
        }
        else
        {
            ReduceCooldown();
        }
        float targetHeight = Mathf.Clamp(transform.position.y + (jumpVelocity * Time.deltaTime), -maxHeigh, maxHeigh);
        transform.position = new Vector3(transform.position.x, targetHeight);

        if (transform.position.y == maxHeigh)
        {
            jumpVelocity = 0;
        }

        if (transform.position.y <= -2.5)
        {
            jumpVelocity = 0;
            ResetPlayerYPosition();
        }
        else
        {
            jumpVelocity -= gravity;
        }
    }

    void ReduceCooldown()
    {
        if (controlCooldown > 0)
        {
            controlCooldown -= Time.deltaTime;
            if (controlCooldown <= 0)
            {
                canControl = true;
            }
        }
    }

    public void ToggleControl(bool toggle)
    {
        canControl = toggle;
    }

    public void ChangeSpriteToHungry()
    {
        ResetAnimationBools();
        anim.SetBool("IsHungry", true);
    }

    public void ChangeSpriteToUnderWater()
    {
        ResetAnimationBools();
        anim.SetBool("IsUnderwater", true);
    }

    public void ChangeSpriteToHappy()
    {
        ResetAnimationBools();
        anim.SetBool("IsHappy", true);
    }

    public void ChangeSpriteToHug()
    {
        ResetAnimationBools();
        anim.SetBool("Hug", true);
    }

    public void ChangeSpriteToShocked()
    {
        ResetAnimationBools();
        anim.SetBool("IsShocked", true);
    }
    
    public void ChangeSpriteToSquashed()
    {
        ResetAnimationBools();
        anim.SetBool("IsSquashed", true);
    }

    public bool IsAnimationBoolPlaying(string name)
    {
        return anim.GetBool(name);
    }
    public void ChangeSpriteToDefault()
    {
        ResetAnimationBools();
    }
    void ResetAnimationBools()
    {
        anim.SetBool("IsHungry", false);
        anim.SetBool("IsUnderwater", false);
        anim.SetBool("IsHappy", false);
        anim.SetBool("Hug", false);
        anim.SetBool("IsShocked", false);
        anim.SetBool("IsSquashed", false);
    }

    public void FreezeControls(float cooldown)
    {
        ToggleControl(false);
        this.controlCooldown = cooldown;
    }

    public void ResetPlayerPosition()
    {
        transform.position = new Vector3(0, -2.5f, 0);
    }

    public void ResetPlayerYPosition()
    {
        transform.position = new Vector3(transform.position.x, -2.5f);
    }

    public void ResetPlayerXPosition()
    {
        transform.position = new Vector3(0, transform.position.y, 0);
    }

    public void PutPlayerNearBond()
    {
        transform.position = new Vector3(-maxWidth + 2, -2.5f, 0);
    }

    public void Animate(string animationName)
    {
        anim.SetTrigger(animationName);
    }

    public void PlaySwimAudio()
    {
        SoundManager.Instance.PlaySingle(swimAudio);
    }

    public void PlaySplashAudio()
    {
        SoundManager.Instance.PlaySingle(splashAudio);
    }

    public IEnumerator SkipAnimation()
    {
        ResetAnimationBools();
        anim.speed = 9999;
        yield return new WaitForSeconds(0.2f);
        anim.speed = 1;
    }
}
