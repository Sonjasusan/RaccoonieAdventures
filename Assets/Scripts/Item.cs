using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour, IInteractable
{
    public ItemData data;

    public void OnEnterInteract()
    {
        InventoryManager.Instance.AddItemToInventory(data);
        XPManager.instance.AddXP(10); //lis‰t‰‰n 10xp:t‰ 
        Destroy(this.gameObject);
    }

    public void OnExitInteract()
    {

    }

    public void OnInteract()
    {

    }
}
