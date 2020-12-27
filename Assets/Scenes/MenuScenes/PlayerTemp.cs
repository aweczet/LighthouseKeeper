using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{
    public int level = 1;
    // public Quest[] quests;
    // public int numberOfActiveQuests;
    // public GameObject uniquepickup;
    // public GameObject uniqueobject;
    // public static bool collectedUnique = false;
    // private QuestSetup questSetup;
    // private GameObject canvas;
    // private LightSwitch lightSwitch;
    // private ColorChange colorChange;
    // private random barometr;
    // private bool allDone = false;
    // private int numberOfAllQuestes;
    // private int lighthouseQuestID;

    public void SavePlayer () {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer () {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        
        // quests = data.quests;
        // numberOfActiveQuests = data.numberOfActiveQuests;
        // uniquepickup = data.uniquepickup;
        // uniqueobject = data.uniqueobject;
        // collectedUnique = data.collectedUnique;
        // questSetup = data.questSetup;
        // canvas = data.canvas;
        // lightSwitch = data.lightSwitch;
        // colorChange = data.colorChange;
        // barometr = data.barometr;
        // allDone = data.allDone;
        // numberOfAllQuestes = data.numberOfAllQuestes;
        // lighthouseQuestID = data.lighthouseQuestID;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
