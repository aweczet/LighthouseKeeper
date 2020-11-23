using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quest
{
    public bool isActive = true;
    public string title;

    [HideInInspector] public Text questName;
    [HideInInspector] public Text strike;

    //public Light swiatlo;
    public QuestGoal questGoal;
    public GameObject[] questItem;
    
    public void completed()
    {
        isActive = false;
        Debug.Log(title + " completed");

        for(int i=0;i<title.Length+1;i++){ strike.text += "_"; }
        //swiatlo.transform.position = new Vector3(-58, 22, 13);
    }
}
