using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData {
    public Quest[] quests;

    public int level;
    public Stack<int> loadedLevels;

    public float[] position; // to też być z playera z innej sceny

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
    

    public PlayerData (Player player) { // Player player
        quests = player.quests;
        
        level = player.level;
        loadedLevels = player.loadedLevels;

        // to musi być z playera z innej sceny
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        // numberOfActiveQuests = player.numberOfActiveQuests;
        // uniquepickup = player.uniquepickup;
        // uniqueobject = player.uniqueobject;
        // collectedUnique = player.collectedUnique;
        // questSetup = player.questSetup;
        // canvas = player.canvas;
        // lightSwitch = player.lightSwitch;
        // colorChange = player.colorChange;
        // barometr = player.barometr;
        // allDone = player.allDone;
        // numberOfAllQuestes = player.numberOfAllQuestes;
        // lighthouseQuestID = player.lighthouseQuestID;
    }
}
