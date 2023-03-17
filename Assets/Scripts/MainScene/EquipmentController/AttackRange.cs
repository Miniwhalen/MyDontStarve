using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyAI>().ChangeHealth(-StoneSpearController.baseAttack);
    }

}
