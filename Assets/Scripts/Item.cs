using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource pickUpSE; //ker‰ilyn ‰‰ni


    public ItemData data;

    public void OnEnterInteract()
    {
        InventoryManager.Instance.AddItemToInventory(data);
        XPManager.instance.AddXP(10); //lis‰t‰‰n 10xp:t‰ 
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
