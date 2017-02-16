using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Play : MonoBehaviour {

    public Slider timer;
    public float timeLeft;

    void Start()
    {

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
    }

}
