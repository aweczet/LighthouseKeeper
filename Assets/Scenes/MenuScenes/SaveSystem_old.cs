// using UnityEngine;
// using System.IO;
// using System.Runtime.Serialization.Formatters.Binary;
//
// public static class SaveSystem_old {
//
//     public static void SavePlayer (Player player) {  // Player player
//         BinaryFormatter formatter = new BinaryFormatter();
//
//         string path = Application.persistentDataPath + "/player.data";
//         FileStream stream = new FileStream(path, FileMode.Create);
//
//         PlayerData_old data = new PlayerData_old(player);
//
//         formatter.Serialize(stream, data);
//         stream.Close();
//     }
//
//     public static PlayerData_old LoadPlayer () {
//         string path = Application.persistentDataPath + "/player.data";
//         
//         if (File.Exists(path)) {
//             BinaryFormatter formatter = new BinaryFormatter();
//
//             FileStream stream = new FileStream(path, FileMode.Open);
//
//             PlayerData_old data = formatter.Deserialize(stream) as PlayerData_old;
//             stream.Close();
//
//             return data;
//
//         } else {
//             Debug.LogError("Save file not found in " + path);
//             return null;
//         }
//     }
//
// }
