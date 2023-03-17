using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private InventorySlot[] slots;

    //point
    private Vector3 inInventory;
    private Vector3 direct;

    public PlayerInventory()
    {
        slots = ReferenceLib.Instance.inventoryController.slots;

        FreshSlots();

        inInventory = new Vector3(120,-130,0);
        direct = new Vector3(0, -300, 0);
    }

    public Item ItemAt(int index)
    {
        return slots[index].item;
    }

    public int AddItem(Item item)
    {
        int index = GetFirstAvailible();
        if (index != -1)
            slots[index].ChangeItem(item);
        return index;
    }

    public void RemoveItem(int index)
    {
        slots[index].ChangeItem(ItemType.EMPTY);
    }

    public int GetFirstAvailible()
    {
        int i = 0;
        while (!slots[i].IsAvailible())
        {
            i++;
            if (i >= 16) return -1;
        }
        return i;
    }

    public void FreshSlots()
    {
        for (int i = 0; i < 16; i++)
        {
            slots[i].FreshSprite();
        }
    }

    public void OpenInventory()
    {
        ReferenceLib.Instance.inventoryPanel.SetActive(true);
        ReferenceLib.Instance.directHotbarPanel.transform.localPosition = inInventory;
    }

    public void CloseInventory()
    {
        ReferenceLib.Instance.inventoryPanel.SetActive(false);
        ReferenceLib.Instance.directHotbarPanel.transform.localPosition = direct;
    }
}
