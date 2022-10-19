using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour, IInteractable
{
    public ItemData data;

    public void OnEnterInteract()
    {
        InventoryManager.Instance.AddItemToInventory(data);

        Destroy(this.gameObject);
    }

    public void OnExitInteract()
    {

    }

    public void OnInteract()
    {

    }
}
