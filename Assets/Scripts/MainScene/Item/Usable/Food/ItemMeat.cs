using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMeat : ItemEatable,ItemCookable
{

    public ItemMeat(string name, Sprite sprite) : base(name, sprite)
    {
        hungerEffect = 10;
        sanEffect = -10;
    }


    public override void Use()
    {
        PlayerController.Instance.ChangeHunger(hungerEffect);
        PlayerController.Instance.ChangeSan(sanEffect);
    }

    public ItemEatable GetCookedItem()
    {
        return (ItemEatable)ItemType.COOKED_MEAT;
    }
}
