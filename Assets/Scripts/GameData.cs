using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player save game
/// </summary>
[Serializable]
public class GameData {

    public bool skipIntro;

    public GameData()
    {
        skipIntro = false;
    }

    public void UpdateGameData(GameData data)
    {
        skipIntro = data.skipIntro;
    }

}
