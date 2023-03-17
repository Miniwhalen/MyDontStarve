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

    public void Collect(CollectableType type,out bool isRightTool)
    {
        int isFull = 0;
        switch (type)
        {
            case CollectableType.WOOD:
                isFull = inventory.AddItem(ItemType.LOG);
                break;
            case CollectableType.STONE:
                isFull = inventory.AddItem(ItemType.STONE_PIECE);
                break;
            case CollectableType.FOOD:
                isFull = inventory.AddItem(ItemType.BERRIES);
                break;
            case CollectableType.COBBLE:
                isFull = inventory.AddItem(ItemType.COBBLESTONE);
                break;
            case CollectableType.STICKDOWN:
                isFull = inventory.AddItem(ItemType.STICK);
                break;
        }
        if (isFull == -1) isRightTool = false;
        else isRightTool = true;
        
    }

    public void CollectDropItem(DropItemController drop,out bool isRightTool)
    {
        if (inventory.AddItem(drop.GetItem()) == -1) isRightTool = false;
        else isRightTool = true;

    }
}
