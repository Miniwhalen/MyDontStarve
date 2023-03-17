using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour,IPointerClickHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Image img;

    public Item item;

    //ui
    private RectTransform rTM;
    Vector3 offset;
    Vector3 originalLocalPosition;

    private void Awake()
    {
        img = GetComponent<Image>();

        rTM = GetComponent<RectTransform>();
        offset = new Vector2();

    }

    public bool IsAvailible()
    {
        return item == ItemType.EMPTY;
    }

    public void ChangeItem(Item item)
    {
        this.item = item;
        FreshSprite();
    }

    public void ThrowThisItem()
    {
        if (item == ItemType.EMPTY) return;
        GameObject dropItemGO = Instantiate(ResourceManager.dropItemPrefab, PlayerController.Instance.transform.position, Quaternion.identity);
        dropItemGO.GetComponent<DropItemController>().SetItem(item);
        ChangeItem(ItemType.EMPTY);
    }

    public void FreshSprite()
    {
        img.sprite = item.sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.pointerId)
        {
            case -1:
                if (eventData.clickCount == 2)
                {
                    if (item is IUsable) {
                        ((IUsable)item).Use();
                        this.ChangeItem(ItemType.EMPTY);
                    }
                    
                }
                break;
            case -2:
                this.ThrowThisItem();
                break;
            case -3:

                break;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = rTM.position - (Vector3)eventData.position;
        originalLocalPosition = rTM.localPosition;
        img.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rTM, eventData.position, eventData.enterEventCamera, out pos);
        rTM.position = pos + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject GO = eventData.pointerCurrentRaycast.gameObject;
        if (GO)
        {
            InventorySlot slot = GO.GetComponent<InventorySlot>();
            if (slot)
            {
                //switch item
                Item temp = this.item;
                this.ChangeItem(slot.item);
                slot.ChangeItem(temp);
            }
        }
        rTM.localPosition = originalLocalPosition;
        img.raycastTarget = true;
    }
}
