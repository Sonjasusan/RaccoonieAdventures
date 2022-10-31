using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiItemData : MonoBehaviour
{
    public Image itemImage;
    public ItemData attachedData;

    public void InitializeItemUI(ItemData data)
    {
        attachedData = data;
        itemImage.sprite = data.itemIcon;
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.RemoveItemFromInventory(attachedData);
        Destroy(this.gameObject);
    }
}
