using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPart : MonoBehaviour
{
    private BonfireController bonfire;

    private void Awake()
    {
        bonfire = GetComponentInParent<BonfireController>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController.Instance.furnitureInDistance = bonfire.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController.Instance.furnitureInDistance = null;
    }
}
