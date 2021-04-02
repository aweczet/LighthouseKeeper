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

    public static void SaveFuelTank(FuelTank fuelTank)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream stream = new FileStream(Application.persistentDataPath + "/fuel.lighthousekeeper", FileMode.Create);

        FuelData data = new FuelData(fuelTank);

        binaryFormatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Fuel saved!");
    }

    public static FuelData LoadFuelTank()
    {
        if (File.Exists(Application.persistentDataPath + "/fuel.lighthousekeeper"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            FileStream stream = new FileStream(Application.persistentDataPath + "/fuel.lighthousekeeper", FileMode.Open);

            FuelData data = binaryFormatter.Deserialize(stream) as FuelData;
            stream.Close();

            return data;
        }

        Debug.LogError("FuelTank file not found! " + Path);
        return null;
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

        Debug.LogError("Save file not found! " + Path);
        return null;
    }
}