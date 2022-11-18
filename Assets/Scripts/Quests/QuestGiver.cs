using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest; //Quest viittaus

    public PlayerController player; //PlayerController viittaus

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text XPRewardText;


    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        XPRewardText.text = quest.XPReward.ToString();
    }

    public void AcceptQuest() //Hyv‰ksyt‰‰n quest
    {
        questWindow.SetActive(false);
        quest.isActive= true;
        player.quest = quest;
    }
}
