using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Klasa zawieracjąca informacje na temat pojedynczego questa oraz
/// metodę pozwalającą na jego zakończenie (i wypisanie podkreślników)
/// </summary>
[System.Serializable]
public class Quest
{
    public bool isActive = true;
    [HideInInspector] public bool isCompleted = false;
    public string title;

    [HideInInspector] public Text questName;
    [HideInInspector] public Text strike;
    private bool strikedthrough;

    //public Light swiatlo;
    public QuestGoal questGoal;
    public GameObject[] questItem;
    public bool destroyItems = false;
    [HideInInspector] public int[] itemID;

    public void completed()
    {
        isActive = false;
        isCompleted = true;
        StrikeQuest();
        if(destroyItems){
            for(int i = 0; i < questItem.Length; i++)
                GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInventory>().removeItemAfterQuest(itemID[i]);

        }
        //swiatlo.transform.position = new Vector3(-58, 22, 13);
    }

    public void StrikeQuest()
    {
        if (isActive)
        {
            strike.text = "";
            return;
        }

        if (strikedthrough)
            return;
        

        for (int i = 0; i < title.Length + 1; i++)
        {
            strike.text += "_";
        }

        strikedthrough = true;
    }
}