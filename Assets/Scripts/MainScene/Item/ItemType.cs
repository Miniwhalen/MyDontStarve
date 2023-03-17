using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType
{
    public static Item EMPTY = new Item("Empty",ResourceManager.itemSprites["Empty"]);
    public static Item BERRIES = new ItemBerries("Berries", ResourceManager.itemSprites["Berries"]);
    public static Item COBBLESTONE = new Item("CobbleStone", ResourceManager.itemSprites["CobbleStone"]);
    public static Item LOG = new Item("Log", ResourceManager.itemSprites["Log"]);
    public static Item STICK = new Item("Stick", ResourceManager.itemSprites["Stick"]);
    public static Item STONE_PIECE = new Item("StonePiece", ResourceManager.itemSprites["StonePiece"]);
    public static Item GOLD_PIECE = new Item("GoldPiece", ResourceManager.itemSprites["GoldPiece"]);
    public static Item STONE_PICKAXE = new Item("StonePickaxe", ResourceManager.itemSprites["StonePickaxe"]);
    public static Item STONE_AXE = new Item("StoneAxe", ResourceManager.itemSprites["StoneAxe"]);
    public static Item BONFIRE_ITEM = new ItemBonfire("BonfireItem", ResourceManager.itemSprites["BonfireItem"]);
    public static Item CRAFTMACHINE_ITEM = new ItemCraftMachine("CraftMachineItem",ResourceManager.itemSprites["CraftMachineItem"]);
    public static Item STONE_SPEAR = new Item("StoneSpear", ResourceManager.itemSprites["StoneSpear"]);
    public static Item MEAT = new ItemMeat("Meat", ResourceManager.itemSprites["Meat"]);
    public static Item COOKED_MEAT = new ItemCookedMeat("CookedMeat", ResourceManager.itemSprites["CookedMeat"]);
    public static Item STONE_HELMET = new ItemStoneHelmet("StoneHelmet",ResourceManager.itemSprites["StoneHelmet"]);

}
