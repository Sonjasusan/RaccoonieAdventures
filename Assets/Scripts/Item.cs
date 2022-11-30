using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource pickUpSE; //ker‰ilyn ‰‰ni
    public XPManager xpmanager; //XPManager Xp:t‰ varten
    public Quest quest;
    public QuestGoal questGoal;

    public ItemData data;

    public void OnEnterInteract()
    {
        InventoryManager.Instance.AddItemToInventory(data);
        XPManager.instance.AddXP(10); //lis‰t‰‰n 10xp:t‰ aina kun ker‰t‰‰n itemi
        pickUpSE.Play(); // Toistetaan ‰‰ni

        Destroy(this.gameObject);
    }

    public void OnExitInteract()
    {
       

    }

    public void OnInteract()
    {

    }
}