using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireController : MonoBehaviour
{
    public enum BonfireState
    {
        EMPTY,
        COOKING,
        COOKED
    }

    private BonfireState state;
    private ItemEatable cookedItem;

    private SpriteRenderer cookPartRenderer;

    private void Awake()
    {
        state = BonfireState.EMPTY;
        cookedItem = null;


        cookPartRenderer = GetComponentInChildren<CookPart>().GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        BurnTimer();
        CookTimer();

    }

    private float burnTimer = 0;
    private void BurnTimer()
    {
        burnTimer += Time.deltaTime;
        if (burnTimer > ItemBonfire.burnTime)
        {
            Destroy(this.gameObject);
        }
    }

    private float cookTimer = 0;
    private void CookTimer()
    {
        if (state == BonfireState.COOKING)
        {
            cookTimer += Time.deltaTime;
            if (cookTimer > 3)
            {
                CookFood();
                cookTimer = 0;
            }
        }
    }

    public void InteractWith(Item item,int index)
    {
        switch (state)
        {
            case BonfireState.EMPTY:
                if (item is ItemCookable) AddFood((ItemEatable)item, index);
                break;
            case BonfireState.COOKED:
                TakeFood();
                break;
        }
    }

    private void AddFood(ItemEatable cookable,int index)
    {
        state = BonfireState.COOKING;
        cookPartRenderer.sprite = ResourceManager.itemSprites[cookable.name];
        PlayerController.Instance.RemoveItemAt(index);
        cookedItem = cookable;
    }

    private void CookFood()
    {
        state = BonfireState.COOKED;
        cookedItem = ((ItemCookable)cookedItem).GetCookedItem();
        cookPartRenderer.sprite = ResourceManager.itemSprites[cookedItem.name];
    }

    private void TakeFood()
    {
        state = BonfireState.EMPTY;
        cookPartRenderer.sprite = ResourceManager.itemSprites["Empty"];
        PlayerController.Instance.GetNewItem(cookedItem);
        cookedItem = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController.Instance.ChangeHaveLight(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController.Instance.ChangeHaveLight(false);
    }

}
