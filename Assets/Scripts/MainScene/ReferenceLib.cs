using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceLib : MonoBehaviour
{
    public static ReferenceLib Instance { get; private set; }
    //ui
    public GameObject interactText;
    public GameObject inventoryPanel;
    public GameObject directHotbarPanel;
    public GameObject craftPanel;
    public GameObject endGamePanel;
    public GameObject healthBar;
    public GameObject hungerBar;
    public GameObject sanBar;

    //controller
    public InventoryController inventoryController;


    private void Awake()
    {
        Instance = this;

    }
}
