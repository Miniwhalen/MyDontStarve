using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //single
    public static PlayerController Instance { get; private set; }

    //move part
    private float hor;
    private float ver;
    public float speed;

    //facing
    private bool isRightFacing;

    //interact
    private bool canInteractNow;
    private GameObject GOinDistance;

    //interact with furniture
    public GameObject furnitureInDistance;

    //inventory
    private bool isInventoryOpen;
    public int currentHoldingIndex;

    //equipment manager
    public EquipmentManager equipmentManager;

    //body part
    private PlayerInventory inventory;
    private PlayerCollect collect;
    private PlayerStatus status;
    private PlayerCraft craft;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        speed = 3;

        isRightFacing = true;

        canInteractNow = false;

        isInventoryOpen = false;
        currentHoldingIndex = 0;

        equipmentManager = GetComponentInChildren<EquipmentManager>();

        inventory = new PlayerInventory();
        collect = new PlayerCollect(inventory);
        status = new PlayerStatus();
        craft = new PlayerCraft(inventory);

    }

    private void Update()
    {
        ProcessMoveInput();
        ProcessKeyInput();
        ProcessFacing();

        status.UpdateCycleStateEffect();
        status.UpdateLocalStatusEffect();
    }

    private void ProcessMoveInput()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

    }

    private void ProcessKeyInput()
    {
        if (canInteractNow)
        {
            if (Input.GetKeyDown(KeyCode.F)) Interact();
            
        }
        if (Input.GetKeyDown(KeyCode.R)) InteractWithFurniture();
        if (Input.GetKeyDown(KeyCode.E)) ShowInventory();
        if (Input.GetKeyDown(KeyCode.G))
        {
            inventory.AddItem(ItemType.STONE_PIECE);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) setCurrentHoldingIndex(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) setCurrentHoldingIndex(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) setCurrentHoldingIndex(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) setCurrentHoldingIndex(3);
    }

    private void ProcessFacing()
    {
        float rawHor = Input.GetAxisRaw("Horizontal");
        if (rawHor > 0) isRightFacing = true;
        else if (rawHor < 0) isRightFacing = false;
        if (isRightFacing) this.transform.rotation = Quaternion.Euler(0, 0, 0);
        else this.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void FixedUpdate()
    {
        Vector2 moveVector = new Vector2(hor, ver) * speed * Time.fixedDeltaTime;
        this.transform.Translate(moveVector,Space.World);
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = this.transform.position + new Vector3(0, 0, -10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReferenceLib.Instance.interactText.SetActive(true);
        GOinDistance = collision.gameObject;
        canInteractNow = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ReferenceLib.Instance.interactText.SetActive(false);
        GOinDistance = null;
        canInteractNow = false;
    }

    private void setCurrentHoldingIndex(int index)
    {
        currentHoldingIndex = index;
        ReferenceLib.Instance.inventoryController.ChangeSelectBack(index);
        equipmentManager.ShowEquipment();
    }

    private void InteractWithFurniture()
    {
        if (furnitureInDistance)
        {
            switch (furnitureInDistance.tag)
            {
                case "Furniture.Bonfire":
                    furnitureInDistance.GetComponent<BonfireController>().InteractWith(inventory.ItemAt(currentHoldingIndex), currentHoldingIndex);

                    break;
            }
        }
    }

    private void Interact()
    {
        bool isRightTool = false;
        if (GOinDistance)
        {
            switch (GOinDistance.tag)
            {
                case "Interact.WOOD":
                    if (inventory.ItemAt(currentHoldingIndex) == ItemType.STONE_AXE)
                    {
                        collect.Collect(PlayerCollect.CollectableType.WOOD, out isRightTool);
                    }
                    break;
                case "Interact.STONE":
                    if (inventory.ItemAt(currentHoldingIndex) == ItemType.STONE_PICKAXE)
                    {
                        collect.Collect(PlayerCollect.CollectableType.STONE, out isRightTool);
                        //random gold
                        if(isRightTool) if (Random.Range(0, 5) == 0) GetNewItem(ItemType.GOLD_PIECE);
                    }
                    break;
                case "Interact.FOOD":
                    collect.Collect(PlayerCollect.CollectableType.FOOD, out isRightTool);
                    break;
                case "Interact.COBBLE":
                    collect.Collect(PlayerCollect.CollectableType.COBBLE, out isRightTool);
                    break;
                case "Interact.STICKDOWN":
                    collect.Collect(PlayerCollect.CollectableType.STICKDOWN, out isRightTool);
                    break;
                case "Interact.DropItem":
                    collect.CollectDropItem(GOinDistance.GetComponent<DropItemController>(), out isRightTool);
                    break;
            }
            if (isRightTool)
            {
                Destroy(GOinDistance);
            }
        }
    }

    private void ShowInventory()
    {
        if (isInventoryOpen) {
            inventory.CloseInventory();
        }
        else 
        {
            inventory.OpenInventory();
        }
        isInventoryOpen = !isInventoryOpen;
    }

    public void GetNewItem(Item item)
    {
        inventory.AddItem(item);
    }

    public void RemoveItemAt(int index)
    {
        inventory.RemoveItem(index);
    }

    public void ChangeHealth(int amount)
    {
        status.setStatus(0, status.health + amount);

        if (status.health==0)
        {
            status.Death();
        }
    }

    public void ChangeHunger(int amount)
    {
        status.setStatus(1, status.hunger + amount);

        if (status.hunger == 0)
        {
            status.Hungery();
        }
    }

    public void ChangeSan(int amount)
    {
        status.setStatus(2, status.san + amount);

        if (status.san == 0)
        {
            status.SanZero();
        }
    }

    public void ChangeHaveLight(bool value)
    {
        status.haveLight = value;
    }

    public void ChangeCraftState(bool nearCraftMachine)
    {
        if (nearCraftMachine)
        {
            craft.GetButtonAt(4).interactable = true;
            craft.GetButtonAt(5).interactable = true;

        }
        else
        {
            craft.GetButtonAt(4).interactable = false;
            craft.GetButtonAt(5).interactable = false;

        }
    }

    public int GetAfterDefenceAmount(int amount)
    {
        int result = amount + status.defenceNum;
        if (result > 0) result = 0;
        if (equipmentManager.helmetObject) 
            equipmentManager.helmetObject.GetComponent<StoneHelmetController>().Use();
        return result;
    }
}
