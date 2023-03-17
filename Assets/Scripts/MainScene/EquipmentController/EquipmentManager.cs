using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    //armor
    public GameObject helmetObject;
    //equipment
    public Dictionary<int, GameObject> equipments;

    private void Awake()
    {
        helmetObject = null;
        equipments = new Dictionary<int, GameObject>();

    }

    public void AddHelmet()
    {
        helmetObject = GameObject.Instantiate(ResourceManager.equipmentGOs["StoneHelmet"],this.transform);
    }

    public void AddEquipment(int index,Item itemCrafted)
    {
        GameObject newEquipment = GameObject.Instantiate(ResourceManager.equipmentGOs[itemCrafted.name], this.transform);
        equipments.Add(index, newEquipment);
        newEquipment.SetActive(false);

    }

    public void ShowEquipment()
    {
        int index = PlayerController.Instance.currentHoldingIndex;
        if (equipments.ContainsKey(index))
        {
            foreach (var equipment in equipments) equipment.Value.SetActive(false);
            equipments[index].SetActive(true);
        }
    }
}
