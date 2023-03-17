using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCookedMeat : ItemEatable
{

    public ItemCookedMeat(string name, Sprite sprite) : base(name, sprite)
    {
        healthEffect = 10;
        hungerEffect = 30;
    }

    public override void Use()
    {
        PlayerController.Instance.ChangeHealth(healthEffect);
        PlayerController.Instance.ChangeHunger(hungerEffect);
    }
}
