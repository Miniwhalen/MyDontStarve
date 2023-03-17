using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTrigger : MonoBehaviour
{
    private EnemyAI ai;

    private void Awake()
    {
        ai = this.GetComponentInParent<EnemyAI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ai.attackTarget = collision.transform;
            ai.state = EnemyAI.State.Attack;
        }
    }
}
