using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHelmetController : MonoBehaviour
{

    public static int maxUseCount;
    public int endurance;

    private void Awake()
    {
        maxUseCount = 16;
        endurance = maxUseCount;

    }

    public void Use()
    {
        endurance--;
        if (endurance <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
