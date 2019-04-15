using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlowPowerup : Powerup
{
    public float startTime;
    public int slowSpeed;
    public int duration;

    public SlowPowerup()
    {
        duration = 3;
        slowSpeed = 50;
        cooldown = 30;
    }

     public void Reset(Image cooldownImage)
    {
        cooldownImage.fillAmount = 0;
    }

    public void Trigger(Image cooldownImage)
    {
        cooldownImage.fillAmount = 1;
        isOnCooldown = true;
        isActive = true;

        startTime = Time.time;
    }

    public void CheckIfComplete()
    {
        if (isActive && Time.time > duration + startTime)
        {
            isActive = false;
        }
    }
}
