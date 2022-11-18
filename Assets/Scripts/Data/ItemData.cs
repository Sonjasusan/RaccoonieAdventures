using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "RA/Create New Item Data", order = 0)]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public ItemType itemType;
    public GameObject itemPrefab;
    [SerializeField] AudioSource pickUpSE; //ker‰ilyn ‰‰ni

    //public SoundEffect pickupSE; <- pickup ‰‰ni
    //public SoundEffect dropSE; <- drop ‰‰ni
}

public enum ItemType //Itemin tyyppi
{
    Consumable,
    Spell
}
