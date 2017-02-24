using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class containing generic stage related data for gameobject
/// </summary>
public class Stage : MonoBehaviour
{
    public bool hidden;
    public bool cleared;
    public String stageName;
    public int numberOfStars;
    public String nextStage;
    public List<GameObject> stars;

    private void Start()
    {

    }

    public Stage()
    {
        hidden = true;
        cleared = false;
        numberOfStars = 0;
        stageName = "";
        nextStage = "";
    }
}
