using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAxeController : MonoBehaviour
{

    private Animator animator;

    public static int maxUseCount;
    public int endurance;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        maxUseCount = 16;
        endurance = maxUseCount;

    }

    private void Update()
    {
        ProcessMouseInput();

    }

    private void ProcessMouseInput()
    {
        if (Input.GetKeyDown(KeyCode.F)) Use();
    }

    private void Use()
    {
        animator.SetTrigger("Use");
        endurance--;
        if (endurance <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
