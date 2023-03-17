using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItemController : MonoBehaviour
{
    private SpriteRenderer render;

    private Item item;

    private void Awake()
    {
        render = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetItem(Item item)
    {
        render.sprite = ResourceManager.itemSprites[item.name];
        this.item = item;
    }

    public Item GetItem()
    {
        return item;
    }
}
