using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    List<ItemData> playerInventory = new List<ItemData>();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UiManager.Instance.ToggleInventoryPanel();
        }
    }

    public void AddItemToInventory(ItemData newItem) //Lis‰t‰‰n itemi
    {
        Debug.Log("Added " + newItem.itemName + " to inventory"); //<-Logataan ett‰ itemi on lis‰tty
        playerInventory.Add(newItem); //Lis‰t‰‰n
     //AudioManager.Instance.PlayClipOnce(newItem.pickupSE); <-Pickupin soundeffect


        UiManager.Instance.CreateNewUIItem(newItem); //UIManageriin uusi itemi
    }

    public void RemoveItemFromInventory(ItemData item)
    {
        if (playerInventory.Contains(item))
        {
            //AudioManager.Instance.PlayClipOnce(item.dropSE); // 
            PlayerController player = GameManager.Instance.Player.GetComponent<PlayerController>();
            //GameObject droppedItem = Instantiate(item.itemPrefab, player.itemDropPoint); //pudotetaan itemi
            //droppedItem.transform.parent = null; // poistetaan tiputettu objekti pelaajasta
            //droppedItem.transform.position += droppedItem.transform.right * Random.Range(-1.0f, 1.0f); // m‰‰ritelty droppoint

            playerInventory.Remove(item); //Poistetaan itemi
            Debug.Log("Removed " + item.itemName + " from inventory"); //Logataan poisto
        }
    }
}

