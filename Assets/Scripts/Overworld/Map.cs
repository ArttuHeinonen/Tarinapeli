using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public List<GameObject> stages;
    public GameData tempData;
    List<StageData> filter;

    void Start () {
        tempData = new GameData();
        filter = new List<StageData>();
        LoadStages();
        HideStages();
	}
	
	public void LoadStages()
    {
        tempData = GetStageDataFromSaveFile();
        filter = tempData.Stages;

        foreach (GameObject stage in stages)
        { 
            foreach (StageData item in filter)
            {
                if(stage.GetComponent<Stage>().stageName == item.name)
                {
                    stage.GetComponent<Stage>().numberOfStars = item.stars;
                    stage.GetComponent<Stage>().hidden = item.hidden;
                    stage.GetComponent<Stage>().cleared = item.cleared;
                    stage.GetComponent<Stage>().nextStage = item.nextStage;
                }
            }
        }
    }

    public void HideStages()
    {
        foreach (GameObject stage in stages)
        {
            if (stage.GetComponent<Stage>().hidden)
            {
                stage.SetActive(false);
            }
            else
            {
                HideStars(stage);
            }
        }
    }

    public void HideStars(GameObject stage)
    {
        int numberOfStars = stage.GetComponent<Stage>().numberOfStars;
        for (int i = 2; i > numberOfStars - 1; i--)
        {
            stage.GetComponent<Stage>().stars[i].SetActive(false);
        }
    }

    public GameData GetStageDataFromSaveFile()
    {
        GameData tempData = new GameData();

        if (DataManager.Instance.DoesSaveFileExist())
        {

            tempData = DataManager.Instance.LoadData();

            if (stages.Count == tempData.Stages.Count)
            {
                return tempData;
            }
        }
        return InitGameData();
    }

    public GameData InitGameData()
    {
        FillGameDataWithStages();
        DataManager.Instance.CreateData();
        return DataManager.Instance.LoadData();
    }

    public void FillGameDataWithStages()
    {
        foreach (GameObject stage in stages)
        {
            StageData data = new StageData();
            data.name = stage.GetComponent<Stage>().stageName;
            data.hidden = stage.GetComponent<Stage>().hidden;
            data.stars = stage.GetComponent<Stage>().numberOfStars;
            data.nextStage = stage.GetComponent<Stage>().nextStage;

        }
    }
}
