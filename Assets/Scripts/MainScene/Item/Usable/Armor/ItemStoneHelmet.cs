using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStoneHelmet : Item,IUsable
{

    public ItemStoneHelmet(string name, Sprite sprite) : base(name, sprite)
    {

    }

    public void Use()
    {
        PlayerController.Instance.equipmentManager.AddHelmet();
    }
}
