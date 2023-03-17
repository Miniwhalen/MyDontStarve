using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCycleController : MonoBehaviour
{
    public enum CycleState
    {
        DAY,
        DUSK,
        NIGHT
    }

    public Animator animDusk;
    public Animator animNight;

    //public static float currentTime;
    private static float timer;
    private static float targetTime;
    public static CycleState cycleState;

    public static int sanDropNum;

    public static float cycleMultiplier;

    static DayCycleController()
    {
        //currentTime = 0;
        timer = 0;
        targetTime = 240;
        cycleState = CycleState.DAY;

        sanDropNum = 0;

        cycleMultiplier = 1f;
    }

    private void Update()
    {
        CycleTimer();

    }

    private void CycleTimer()
    {
        timer += Time.deltaTime;
        //print(timer);
        if (timer >= targetTime * cycleMultiplier)
        {
            NextCycleState();
            ShowPanel();
            timer = 0;
        }
    }

    private void ShowPanel()
    {
        switch (cycleState)
        {
            case CycleState.DAY:
                animNight.SetTrigger("WaitState");
                break;
            case CycleState.DUSK:
                animDusk.SetTrigger("InState");
                break;
            case CycleState.NIGHT:
                animDusk.SetTrigger("WaitState");
                animNight.SetTrigger("InState");
                break;
        }
    }

    private void NextCycleState()
    {
        switch (cycleState)
        {
            case CycleState.DAY:
                cycleState = CycleState.DUSK;
                targetTime = 60;
                sanDropNum = 1;
                break;
            case CycleState.DUSK:
                cycleState = CycleState.NIGHT;
                targetTime = 180;
                sanDropNum = 10;
                break;
            case CycleState.NIGHT:
                cycleState = CycleState.DAY;
                targetTime = 240;
                sanDropNum = 0;
                break;
        }
    }


}
