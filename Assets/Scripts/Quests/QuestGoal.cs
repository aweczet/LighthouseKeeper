using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa zawiera informacje na temat celu questa
/// </summary>

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

    // Metoda obracająca przycisk (imitacja przełączenia)
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

// Typy questów
public enum GoalType
{
    press,
    collect,
    light,
    color,
    area,
    lighthouse
}
