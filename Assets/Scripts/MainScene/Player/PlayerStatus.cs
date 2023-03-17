using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus
{
    private Slider healthBar;
    private Slider hungerBar;
    private Slider sanBar;

    public int health;
    public int hunger;
    public int san;

    public bool isHungery;
    public bool isSanZero;

    public bool haveLight;

    public int defenceNum;

    public PlayerStatus()
    {
        healthBar = ReferenceLib.Instance.healthBar.GetComponent<Slider>();
        hungerBar = ReferenceLib.Instance.hungerBar.GetComponent<Slider>();
        sanBar = ReferenceLib.Instance.sanBar.GetComponent<Slider>();

        health = 100;
        hunger = 100;
        san = 100;

        isHungery = false;

        haveLight = false;

        defenceNum=0;
    }

    public void setStatus(int index,int value)
    {
        if (value > 100) value = 100;
        else if (value < 0) value = 0;

        switch (index)
        {
            case 0:
                health = value;
                healthBar.value = health;
                break;
            case 1:
                hunger = value;
                hungerBar.value = hunger;
                break;
            case 2:
                san = value;
                sanBar.value = san;
                break;
        }
    }

    public void Death()
    {
        SystemController.ShowEndGame();
    }

    public void Hungery()
    {
        isHungery = true;
    }

    public void SanZero()
    {
        isSanZero = true;
    }


    private void ResetNegitiveTimer()
    {
        if (sanTimer > 0.5f) sanTimer = 0;
        if (darkTimer > 0.5f) darkTimer = 0;

    }

    private float hungerTimer = 0;
    private float hungerDropInterval = 10;
    private int hungerDropNum = 1;
    private void HungerDropEffect()
    {
        hungerTimer += Time.deltaTime;
        if (hungerTimer > hungerDropInterval * DayCycleController.cycleMultiplier)
        {
            setStatus(1, hunger - hungerDropNum);
            hungerTimer = 0;
        }
    }

    private float sanTimer = 0;
    private float sanDropInterval = 10;

    private void SanDropEffect()
    {
        sanTimer += Time.deltaTime;
        if (sanTimer > sanDropInterval * DayCycleController.cycleMultiplier)
        {
            setStatus(2, san - DayCycleController.sanDropNum);
            sanTimer = 0;
        }
    }

    private float darkTimer = 0;
    private float darkPunishInterval = 5;
    private void DarkEffect()
    {
        if (DayCycleController.cycleState == DayCycleController.CycleState.NIGHT)
        {
            if (!haveLight)
            {
                darkTimer += Time.deltaTime;
                if (darkTimer > darkPunishInterval)
                {
                    setStatus(0, health - 50);
                    setStatus(2, san - 10);
                    darkTimer = 0;
                }
            }
        }
    }

    public void UpdateCycleStateEffect()
    {
        //hunger
        HungerDropEffect();
        //san
        switch (DayCycleController.cycleState)
        {
            case DayCycleController.CycleState.DAY:
                ResetNegitiveTimer();
                break;
            case DayCycleController.CycleState.DUSK:
                SanDropEffect();
                break;
            case DayCycleController.CycleState.NIGHT:
                if (!haveLight) SanDropEffect();
                break;
        }
        //dark
        DarkEffect();

    }

    private float hungeryTimer = 0;
    private float hungeryEffectInterval = 1;
    private void HungerZeroEffect()
    {
        if (isHungery)
        {
            hungeryTimer += Time.deltaTime;
            if (hungeryTimer > hungeryEffectInterval)
            {
                setStatus(0, health - 1);
                hungeryTimer = 0;
            }
            if (hunger != 0) isHungery = false;
        }
    }

    private float sanZeroTimer = 0;
    private float sanZeroEffectInterval = 5;
    private void SanZeroEffect()
    {
        if (isSanZero)
        {
            //effect

            if (san != 0) isSanZero = false;
        }
    }

    public void UpdateLocalStatusEffect()
    {
        HungerDropEffect();
        SanZeroEffect();
    }

}
