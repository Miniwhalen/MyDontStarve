using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBonfire : Item, IUsable
{
    public static float burnTime;

    public ItemBonfire(string name, Sprite sprite) : base(name, sprite)
    {
        burnTime = 240;

    }

    public void Use()
    {
        GameObject.Instantiate(ResourceManager.furnitureGOs["Bonfire"], PlayerController.Instance.transform.position, Quaternion.identity);

    }
}
