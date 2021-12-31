using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveScript
{
    
    public static void SaveGame(Save save)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/LevelSystem";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(save);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static SaveData LoadGame()
    {
        string path = Application.persistentDataPath + "/LevelSystem";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;

        } 
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }

}
