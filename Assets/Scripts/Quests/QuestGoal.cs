using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //serialisoidaan niin voidaan muokata unity editorissa
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount; //tarvittavam‰‰r‰
    public int currentAmount; //t‰m‰n hetkinen m‰‰r‰


    //Tarkistetaan onko tavoite saavutettu
    public bool IsReached() //<- boolean (eli true tai false)
    {
        return (currentAmount >= requiredAmount); //On saavutettu = IsReached -> true
    }


    public void ItemCollected() //itemiker‰ys quest
    {
        if (goalType == GoalType.Gathering)
            currentAmount++; //kasvatetaan sen hetkist‰ m‰‰r‰‰
        Debug.Log("Collected." + currentAmount);
        

    }

    //public void LevelReached()
    //{
    //    if (XPManager.instance.level == 5)
    //    {

    //    }
    //}
}

//Quest tavoitteen tyyppi
public enum GoalType
{
    Gathering //ker‰ily
}