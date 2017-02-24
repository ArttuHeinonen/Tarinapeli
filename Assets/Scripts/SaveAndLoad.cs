using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad
{

    public void SaveGame(GameData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/data.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    public void SaveSettings(Settings settings)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/settings.dat");
        bf.Serialize(file, settings);
        file.Close();
    }

    public GameData LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/data.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/data.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();
            return data;
        }
        Debug.Log("Save file not found!");
        return null;
    }

    public Settings LoadSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/settings.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/settings.dat", FileMode.Open);
            Settings settings = (Settings)bf.Deserialize(file);
            file.Close();
            settings.UpdateSettings(settings);
            return settings;
        }
        Debug.Log("Save file not found!");
        return null;
    }

    public void DeleteSave()
    {
        if (File.Exists(Application.persistentDataPath + "/data.dat"))
        {
            File.Delete(Application.persistentDataPath + "/data.dat");
        }
    }
}
