using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect
{
    private PlayerInventory inventory;

    public enum CollectableType
    {
        WOOD,
        STONE,
        FOOD,
        COBBLE,
        STICKDOWN
    }

    public PlayerCollect(PlayerInventory inventory)
    {
        this.inventory = inventory;

    }

    public void Collect(CollectableType type)
    {
        switch (type)
        {
            case CollectableType.WOOD:
                inventory.AddItem(ItemType.LOG);
                break;
            case CollectableType.STONE:
                inventory.AddItem(ItemType.STONE_PIECE);
                break;
            case CollectableType.FOOD:
                inventory.AddItem(ItemType.BERRIES);
                break;
            case CollectableType.COBBLE:
                inventory.AddItem(ItemType.COBBLESTONE);
                break;
            case CollectableType.STICKDOWN:
                inventory.AddItem(ItemType.STICK);
                break;
        }
        
    }
}
