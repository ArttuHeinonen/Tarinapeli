using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour {

	public static DataManager Instance;

    GameData gameData;
    Settings settings;
    private SaveAndLoad saveAndLoad;

    #region Properties
    public GameData GameData
    {
        get
        {
            return gameData;
        }

        set
        {
            gameData = value;
        }
    }
    public Settings Settings
    {
        get
        {
            return settings;
        }

        set
        {
            settings = value;
        }
    }
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        saveAndLoad = new SaveAndLoad();
        //TODO: Try to load files
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
		
	}

    public void CreateData()
    {
        GameData = new GameData();
        saveAndLoad.SaveGame(GameData);
    }

    public void SaveData(GameData gameData)
    {
        saveAndLoad.SaveGame(gameData);
    }

    public GameData LoadData()
    {
        return saveAndLoad.LoadGame();
    }

    public bool DoesSaveFileExist()
    {
        if (File.Exists(Application.persistentDataPath + "/data.dat"))
        {
            return true;
        }
        return false;
    }

    public bool DoesSettingsExist()
    {
        if (File.Exists(Application.persistentDataPath + "/settings.dat"))
        {
            return true;
        }
        return false;
    }

    public void DeleteData()
    {
        if (DoesSaveFileExist())
        {
            saveAndLoad.DeleteSave();
        }
    }

}
