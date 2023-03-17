using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State
    {
        Attack,
        Idle,
    }

    private PlayerController player;

    private EnemyMotor motor;
    private EnemyAttack attack;
    private EnemyStatus status;

    public State state;
    public Transform attackTarget;

    private void Awake()
    {
        player = PlayerController.Instance;

        status = new EnemyStatus();
        motor = new EnemyMotor(this.transform);
        attack = new EnemyAttack(status);
        

        state = State.Idle;
        this.transform.Find("EnemyRange").gameObject.AddComponent<RangeTrigger>();

    }

    private void Update()
    {
        //state machine
        switch (state)
        {
            case State.Attack:
                float distance = Vector2.Distance(this.transform.position, attackTarget.position);
                if (distance < 0.5f)
                {
                    AttackTimer();
                }
                else if (distance > 10)
                {
                    attackTarget = null;
                    state = State.Idle;
                }
                else
                {
                    motor.MoveToTarget(attackTarget);
                }

                break;
            case State.Idle:

                break;
        }
    }

    private float attackInterval = 1;
    private float attackTimer = 0;
    private void AttackTimer()
    {
        if (Time.time > attackTimer)
        {
            attack.Attack();
            attackTimer = Time.time + attackInterval;
        }
    }

    public void ChangeHealth(int amount)
    {
        status.setHealth(status.health + amount);
        if (status.health == 0)
        {
            status.Death(this.gameObject);
        }
    }
}
