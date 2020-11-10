using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Quest[] quests;

    public void pressedOnSelectable(GameObject item)
    {
        // To fix (optimalization) maybe?
        foreach (Quest quest in quests)
        {
            if (quest.isActive)
            {
                foreach (GameObject questItem in quest.questItem)
                    if (item == questItem)
                    {
                        quest.questGoal.objectPressed();
                        quest.questGoal.objectCollected();

                        if(quest.questGoal.goalType == GoalType.collect)
                            Destroy(questItem);
                        quest.questItem = quest.questItem.Where(e => e != questItem).ToArray();
                        if (quest.questGoal.isReached())
                        {
                            quest.completed();
                        }
                    }
            }

        }

    }

}
