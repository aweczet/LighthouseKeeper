using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    private static readonly string Path = Application.persistentDataPath + "/data.lighthousekeeper";

    public static void SaveGame(Player player)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream stream = new FileStream(Path, FileMode.Create);

        LighthouseData data = new LighthouseData(player);

        binaryFormatter.Serialize(stream, data);
        stream.Close();
    }

    public static LighthouseData LoadGame()
    {
        if (File.Exists(Path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            FileStream stream = new FileStream(Path, FileMode.Open);

            LighthouseData data = binaryFormatter.Deserialize(stream) as LighthouseData;
            stream.Close();

            return data;
        }

        Debug.LogError("Save file not found! " + Path);
        return null;
    }

    public static void DeleteData()
    {
        try
        {
            File.Delete(Path);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}