using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource pickUpSE; //ker‰ilyn ‰‰ni
    public XPManager xpmanager;
    public XPBar xpBar;
    public QuestGoal questgoal;
    public Quest quest;

    public ItemData data;

    public void OnEnterInteract()
    {
        InventoryManager.Instance.AddItemToInventory(data);
        XPManager.instance.AddXP(10); //lis‰t‰‰n 10xp:t‰
        //xpBar.IncrementXPProg();

        pickUpSE.Play(); // Toistetaan ‰‰ni
        //questgoal.ItemCollected();
        Destroy(this.gameObject);
    }

    public void OnExitInteract()
    {

    }

    public void OnInteract()
    {

    }
}