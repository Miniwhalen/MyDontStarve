using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack
{

    private EnemyStatus status;

    public EnemyAttack(EnemyStatus status)
    {
        this.status = status;

    }

    public void Attack()
    {
        PlayerController.Instance.ChangeHealth(PlayerController.Instance.GetAfterDefenceAmount(-status.attackNum));
    }
}
