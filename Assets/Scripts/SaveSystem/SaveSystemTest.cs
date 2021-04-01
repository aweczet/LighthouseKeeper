

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemTest
{
    static readonly string Path = Application.persistentDataPath + "/player.lighthousekeeper";
    
    public static void SavePlayer(Transform player)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        
        FileStream stream = new FileStream(Path, FileMode.Create);

        PlayerDataTest data = new PlayerDataTest(player);
        
        binaryFormatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerDataTest LoadPlayer()
    {
        if (File.Exists(Path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
        
            FileStream stream = new FileStream(Path, FileMode.Open);
            
            PlayerDataTest data = binaryFormatter.Deserialize(stream) as PlayerDataTest;
            stream.Close();
            
            return data;
        }
        else
        {
            Debug.LogError("Save file not found! " + Path);
            return null;
        }
    }
}
