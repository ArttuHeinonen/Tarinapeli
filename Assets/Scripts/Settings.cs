using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// File for settings file. If does not excist starts intro
/// </summary>
[Serializable]
public class Settings {

    public bool fullscreen;
    public int antiAliasing;
    public int vSync;

	public void UpdateSettings(Settings settings)
    {

    }

    public void ResetDefaulSettings()
    {
        
    }
}
