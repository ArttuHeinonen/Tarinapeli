using System;
using System.Collections.Generic;

/// <summary>
/// Player save game
/// </summary>
[Serializable]
public class GameData {

    private List<StageData> stages;
    #region Properties
    public List<StageData> Stages
    {
        get
        {
            return stages;
        }

        set
        {
            stages = value;
        }
    }
    #endregion

    public GameData()
    {
        Stages = new List<StageData>();
    }

}
