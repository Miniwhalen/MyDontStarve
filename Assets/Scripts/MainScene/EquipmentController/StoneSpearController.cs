using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpearController : MonoBehaviour
{

    private Animator animator;

    public static int baseAttack;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        baseAttack = 25;

    }

    private void Update()
    {
        ProcessMouseInput();

    }

    private void ProcessMouseInput()
    {
        if (Input.GetMouseButtonDown(0)) animator.SetTrigger("Attack");
    }
}
