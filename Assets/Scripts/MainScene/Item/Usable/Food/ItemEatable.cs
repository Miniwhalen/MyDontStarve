using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemEatable : Item, IUsable
{
    protected int healthEffect;
    protected int hungerEffect;
    protected int sanEffect;

    public ItemEatable(string name, Sprite sprite) : base(name, sprite)
    {

    }

    public abstract void Use();

}
