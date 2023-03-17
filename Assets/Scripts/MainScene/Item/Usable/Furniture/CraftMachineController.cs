using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMachineController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController.Instance.ChangeCraftState(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController.Instance.ChangeCraftState(false);
    }
}
