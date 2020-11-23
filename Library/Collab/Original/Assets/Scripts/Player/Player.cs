using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;



public class Player : MonoBehaviour
{
    public Quest[] quests;
    public int numberOfActiveQuests;

    // To fix
    public LightSwitch przelacznik;

    void Awake()
    {
        foreach (Quest quest in quests)
        {
            quest.plik.text = quest.title;
            numberOfActiveQuests += quest.isActive ? 1 : 0;
        }
    }

    
    public void pressedOnSelectable(GameObject item)
    {
        if (item.name == "LightSwitch")
        {
            przelacznik.toggleLight();
            //quests.completed();
        }
        //if(item.name == "Flaga")
        //{
        //    Destroy(item);
        //}
        // To fix (optimalization) maybe?
        numberOfActiveQuests = 0;
        foreach (Quest quest in quests)
        {
            
            if (quest.isActive)
            {
                numberOfActiveQuests += quest.isActive ? 1 : 0;

                foreach (GameObject questItem in quest.questItem)
                    if (item == questItem)
                    {
                        quest.questGoal.objectPressed();
                        quest.questGoal.objectCollected();
                        

                        if (quest.questGoal.goalType == GoalType.collect)
                            Destroy(questItem);

                        quest.questItem = quest.questItem.Where(e => e != questItem).ToArray();

                        if (quest.questGoal.isReached())
                        {
                            if (quest.questGoal.goalType == GoalType.collect)
                            {

                            }
                            quest.completed();
                            numberOfActiveQuests--;
                        }
                    }
                    
            }

        }

    }

}
