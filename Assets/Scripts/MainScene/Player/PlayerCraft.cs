using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCraft
{

    private PlayerInventory inventory;

    private GameObject craftPanelGO;
    private Button[] craftsBtn;

    //private bool nearCraftMachine;

    public PlayerCraft(PlayerInventory inventory)
    {
        this.inventory = inventory;

        craftPanelGO = ReferenceLib.Instance.craftPanel;
        craftsBtn = craftPanelGO.GetComponentsInChildren<Button>();
        foreach (var btn in craftsBtn)
        {
            btn.onClick.AddListener(() => {
                switch (btn.name)
                {
                    case "Btn_StoneAxe":
                        Craft(ItemType.STONE_AXE);
                        break;
                    case "Btn_StonePickaxe":
                        Craft(ItemType.STONE_PICKAXE);
                        break;
                    case "Btn_Bonfire":
                        Craft(ItemType.BONFIRE_ITEM);
                        break;
                    case "Btn_CraftMachine":
                        Craft(ItemType.CRAFTMACHINE_ITEM);
                        break;
                    case "Btn_StoneSpear":
                        Craft(ItemType.STONE_SPEAR);
                        break;
                    case "Btn_StoneHelmet":
                        Craft(ItemType.STONE_HELMET);
                        break;
                }
            });
        }

        //nearCraftMachine = false;

    }

    public void Craft(Item itemToCraft)
    {
        if (itemToCraft == ItemType.STONE_AXE && HaveEnoughMaterial(ItemType.STICK, ItemType.STICK, ItemType.COBBLESTONE, ItemType.COBBLESTONE))
            PlayerController.Instance.equipmentManager.AddEquipment(inventory.AddItem(ItemType.STONE_AXE),ItemType.STONE_AXE);
        if (itemToCraft == ItemType.STONE_PICKAXE && HaveEnoughMaterial(ItemType.STICK, ItemType.STICK, ItemType.COBBLESTONE, ItemType.COBBLESTONE))
            PlayerController.Instance.equipmentManager.AddEquipment(inventory.AddItem(ItemType.STONE_PICKAXE), ItemType.STONE_PICKAXE);
        if (itemToCraft == ItemType.BONFIRE_ITEM && HaveEnoughMaterial(ItemType.LOG, ItemType.LOG, ItemType.STICK))
            inventory.AddItem(ItemType.BONFIRE_ITEM);
        if (itemToCraft == ItemType.CRAFTMACHINE_ITEM && HaveEnoughMaterial(ItemType.LOG, ItemType.LOG, ItemType.STONE_PIECE,ItemType.GOLD_PIECE))
            inventory.AddItem(ItemType.CRAFTMACHINE_ITEM);
        if (itemToCraft == ItemType.STONE_SPEAR && HaveEnoughMaterial(ItemType.STICK,ItemType.STICK,ItemType.STONE_PIECE))
            PlayerController.Instance.equipmentManager.AddEquipment(inventory.AddItem(ItemType.STONE_SPEAR), ItemType.STONE_SPEAR);
        if (itemToCraft == ItemType.STONE_HELMET && HaveEnoughMaterial(ItemType.STONE_PIECE, ItemType.STONE_PIECE, ItemType.STONE_PIECE, ItemType.STONE_PIECE))
            inventory.AddItem(ItemType.STONE_HELMET);
    }

    private bool HaveEnoughMaterial(params Item[] materials)
    {
        int[] checkTemp = new int[16];
        foreach (var matarial in materials)
        {
            for (int i = 0; i < 16; i++)
            {
                if (checkTemp[i] == 0)
                {
                    if (inventory.ItemAt(i) == matarial)
                    {
                        checkTemp[i] = 1;
                        goto outter;
                    }
                }
            }
            return false;
            outter: continue;
        }
        for (int i = 0; i < 16; i++)
            if (checkTemp[i] == 1) inventory.RemoveItem(i);
        return true;
    }

    public Button GetButtonAt(int index)
    {
        return craftsBtn[index];
    }
}
