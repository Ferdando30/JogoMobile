using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting.FullSerializer;

public static class SaveSystem
{
    public static void Save(TotalCarots totalCarots, HighScore highScoreClass)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.binary";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(totalCarots, highScoreClass);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log(data + " " + totalCarots);
    }

    public static GameData Load()
    {
        string path = Application.persistentDataPath + "/save.binary";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("No save file found at " + path);
            return null;
        }
    }
}
