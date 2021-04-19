using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LighthouseData
{
    public int sceneId;
    public float[] playerPosition;
    public int numberOfActiveQuests;

    public bool[] questsStatus;
    
    //     level = data.level;
    //     quests = data.quests;
    //     loadedLevels = data.loadedLevels;
    //
    //     // numberOfActiveQuests = data.numberOfActiveQuests;
    //     // uniquepickup = data.uniquepickup;
    //     // uniqueobject = data.uniqueobject;
    //     // collectedUnique = data.collectedUnique;
    //     // questSetup = data.questSetup;
    //     // canvas = data.canvas;
    //     // lightSwitch = data.lightSwitch;
    //     // colorChange = data.colorChange;
    //     // barometr = data.barometr;
    //     // allDone = data.allDone;
    //     // numberOfAllQuestes = data.numberOfAllQuestes;
    //     // lighthouseQuestID = data.lighthouseQuestID;

    public LighthouseData(Player player)
    {
        sceneId = player.level;
        var playerTransform = player.GetComponent<Transform>();
        playerPosition = Vector3ToFloats(playerTransform.position);

        numberOfActiveQuests = player.numberOfActiveQuests;
    
        questsStatus = new bool[player.quests.Length-1];

        for (int i = 0; i < player.quests.Length-1; i++)
        {
            questsStatus[i] = player.quests[i].isActive;
        }
    }

    private float[] Vector3ToFloats(Vector3 vector3)
    {
        float[] floats = new float[3];
        for (int i = 0; i < 3; i++)
        {
            floats[i] = vector3[i];
        }

        return floats;
    }

    public Vector3 FloatsToVector3(float[] floats)
    {
        Vector3 vector3 = new Vector3();
        for (int i = 0; i < 3; i++)
        {
            vector3[i] = floats[i];
        }

        return vector3;
    }
}
