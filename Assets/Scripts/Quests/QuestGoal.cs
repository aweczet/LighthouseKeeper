using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requiredAmmount;
    public int currentAmmount;

    public bool IsReached()
    {
        return (currentAmmount >= requiredAmmount);
    }

    public void FlipModel(Transform selection)
    {
        selection.transform.localScale = new Vector3(selection.transform.localScale.x * -1,
                        selection.transform.localScale.y,
                        selection.transform.localScale.z * -1);
    }

    //public void objectPressed()
    //{
    //    if (goalType == GoalType.press)
    //        currentAmmount++;
    //}

    //public void objectCollected()
    //{
    //    if (goalType == GoalType.collect)
    //        currentAmmount++;
    //}
    //public void placeReached()
    //{
    //    if (goalType == GoalType.place)
    //        currentAmmount++;
    //}
}

public enum GoalType
{
    press,
    collect,
    light,
    color,
    area,
    lighthouse
}
