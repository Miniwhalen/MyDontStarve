using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBerries : ItemEatable
{

    public ItemBerries(string name,Sprite sprite) : base(name,sprite)
    {
        healthEffect = 5;
        hungerEffect = 5;
    }

    public override void Use()
    {
        PlayerController.Instance.ChangeHealth(healthEffect);
        PlayerController.Instance.ChangeHunger(hungerEffect);
    }
}
