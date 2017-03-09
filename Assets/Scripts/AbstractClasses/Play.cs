using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Play : MonoBehaviour {

    public Camera cam;
    public GameObject player;
    public Slider timer;
    public Text timerText;
    public Score score;
    public float timeLeft;
    public float maxTime;
    public bool canControl;
    public bool isOnCooldown;
    public float cooldownTime = 0;

    public float screenWidth;
    public float screenHeight;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        canControl = false;
        Vector3 screenLimits = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        screenWidth = screenLimits.x;
        screenHeight = screenLimits.y;
        ResetTime();
    }

    public abstract void UpdatePlay();
    public abstract void ResetValues();
    public abstract void ActivateSpawn();
    public abstract void ActivateMusic();

    public void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        timer.value = Mathf.RoundToInt(timeLeft);
        timerText.text = timer.value.ToString();
    }

    public void ReduceCooldown()
    {
        if(cooldownTime > 0)
        {
            cooldownTime -= Time.deltaTime;
            if(cooldownTime <= 0)
            {
                canControl = true;
                isOnCooldown = false;
                cooldownTime = 0;
            }
        }
    }

    public void ResetTime()
    {
        timer.maxValue = maxTime;
        timeLeft = maxTime;
        timer.value = maxTime;
    }

    public void ToggleControl()
    {
        canControl = !canControl;
    }
}
