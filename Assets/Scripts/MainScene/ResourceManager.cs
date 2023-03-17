using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static Dictionary<string, Sprite> itemSprites;
    public static Dictionary<string, GameObject> furnitureGOs;
    public static Dictionary<string, GameObject> equipmentGOs;

    static ResourceManager()
    {
        itemSprites = new Dictionary<string, Sprite>();
        furnitureGOs = new Dictionary<string, GameObject>();
        equipmentGOs = new Dictionary<string, GameObject>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Pics/MainScene/Item");
        foreach (var sprite in sprites)
        {
            itemSprites.Add(sprite.name, sprite);
        }
        GameObject[] furnitures = Resources.LoadAll<GameObject>("Prefabs/Furniture");
        foreach (var prefab in furnitures)
        {
            furnitureGOs.Add(prefab.name, prefab);
        }
        GameObject[] equipments = Resources.LoadAll<GameObject>("Prefabs/Equipment");
        foreach (var prefab in equipments)
        {
            equipmentGOs.Add(prefab.name, prefab);
        }

    }
}
