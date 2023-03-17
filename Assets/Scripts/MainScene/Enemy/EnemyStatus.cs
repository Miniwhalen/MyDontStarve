using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus
{
    public int health;
    public int attackNum;

    public EnemyStatus()
    {
        health = 100;
        attackNum = 25;

    }

    public void setHealth(int value)
    {
        if (value > 100) value = 100;
        else if (value < 0) value = 0;

        health = value;
    }

    public void Death(GameObject GO)
    {
        PlayerController.Instance.GetNewItem(ItemType.MEAT);
        GameObject.Destroy(GO);
    }

}
