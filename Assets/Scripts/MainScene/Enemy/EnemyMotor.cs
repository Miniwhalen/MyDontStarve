using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotor
{
    private Transform transform;
    private float speed;

    public EnemyMotor(Transform transform)
    {
        this.transform = transform;
        speed = 2;
    }

    public void MoveToTarget(Transform targetTM)
    {
        MoveToTarget(targetTM.position);
    }

    public void MoveToTarget(Vector2 targetPoint)
    {
        Vector2 dir = targetPoint - (Vector2)transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }
     
}
