using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCraftMachine:Item,IUsable
{

    public ItemCraftMachine(string name, Sprite sprite) : base(name, sprite)
    {
        
    }

    public void Use()
    {
        GameObject.Instantiate(ResourceManager.furnitureGOs["CraftMachine"], PlayerController.Instance.transform.position, Quaternion.identity);

    }
}
