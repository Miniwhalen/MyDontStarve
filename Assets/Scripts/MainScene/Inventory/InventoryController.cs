using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public InventorySlot[] slots;
    private Image[] selectBackImages;

    public GameObject slotPrefab;

    private Transform hotbarTM;
    private Transform coolbarTM;

    private void Awake()
    {
        hotbarTM = this.transform.parent.Find("Panel_Hotbar");
        coolbarTM = this.transform.Find("Panel_Coolbar");

        slots = new InventorySlot[16];
        selectBackImages = new Image[4];
        GenerateSlots();

        //init
        hotbarTM.transform.localPosition = new Vector3(0,-300,0);
        this.gameObject.SetActive(false);
    }

    private void GenerateSlots()
    {
        GameObject slotGO;
        for (int i = 0; i < 16; i++)
        {
            if (i < 4)
            {
                slotGO = Instantiate(slotPrefab,hotbarTM);
                selectBackImages[i] = slotGO.transform.GetChild(0).GetComponent<Image>();
            }
            else
            {
                slotGO = Instantiate(slotPrefab, coolbarTM);
            }
            slots[i] = slotGO.GetComponent<InventorySlot>();
            slots[i].item = ItemType.EMPTY;
            
        }
    }

    public void ChangeSelectBack(int index)
    {
        foreach (var image in selectBackImages) image.color = new Color(0, 0, 0, 0);
        selectBackImages[index].color = new Color(0, 0, 0, 0.4f);
    }
}
