using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public bool isActive; //boolean kertomaan onko questi aktiivinen

    public string title; //questin aihe
    public string description; //questin kuvaus
    public int XPReward; //XP -palkinto


    public QuestGoal goal;

    public void Complete()
    {
        isActive = false; //isActive falseksi 
        Debug.Log(title + " was completed!"); //logataan että questi on tehty
    }
}
