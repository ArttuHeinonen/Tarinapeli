﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{

    public static BackgroundManager Instance { get; private set; }

    public List<Sprite> backgrounds;
    public int currentBackground;
    private GameObject child;
    private SpriteRenderer sr;

    private void Awake()
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

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentBackground = 0;
        ResizeBackground();
    }

    public void SwapToNextBackground()
    {
        currentBackground++;
        UpdateBackground();
    }

    public void SwapToPrevBackground()
    {
        currentBackground--;
        UpdateBackground();
    }
    /// <summary>
    /// Swap to specific background
    /// </summary>
    /// <param name="i">Background number from the list. Note! Counting starts from 0!</param>
    public void SwapToBackGround(int i)
    {
        if(i < 0 || i > backgrounds.Count)
        {
            Debug.Log("Error! Given background on position " + i + " not found!");
            return;
        }
        currentBackground = i;
        UpdateBackground();
    }

    public void UpdateBackground()
    {
        sr.sprite = backgrounds[currentBackground];
        ResizeBackground();
    }


    void ResizeBackground()
    {
        if (sr == null)
        {
            return;
        }
        transform.localScale = new Vector3(1, 1, 1);
        float width = sr.bounds.size.x;
        float height = sr.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight * Screen.width / Screen.height;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        transform.localScale = xWidth;

        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height;
        transform.localScale = yHeight;

        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
    }

    public void HideChild()
    {
        if (this.gameObject.transform.GetChild(0) != null)
        {
            child = this.gameObject.transform.GetChild(0).gameObject;
            child.SetActive(false);
        }
        
    }
}
