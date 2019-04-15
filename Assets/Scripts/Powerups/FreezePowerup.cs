using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FreezePowerup : Powerup
{
    public float startTime;
    public float timeLeftOver;
    public int duration;

    public int unlockPrice;

    public FreezePowerup()
    {
        duration = 3;
        cooldown = 45;
        isUnlocked = false;

        unlockPrice = 500;
    }

    public void Reset(Image cooldownImage)
    {
        cooldownImage.fillAmount = 0;
    }

    public void Trigger(float nextWordTime, Image cooldownImage)
    {
        cooldownImage.fillAmount = 1;
        isOnCooldown = true;
        isActive = true;

        timeLeftOver = nextWordTime - Time.time;
        startTime = Time.time;

        GameManager.generate = false;
    }

    public void CheckIfComplete(WordTimer wordTimer)
    {
        if (isActive && Time.time > duration + startTime)
        {
            GameManager.generate = true;
            isActive = false;
            wordTimer.nextWordTime = Time.time + timeLeftOver;
        }
    }

    public void CheckIfLocked(Sprite lockSprite, Image image)
    {
        if (!isUnlocked)
        {
            image.sprite = lockSprite;
        }
    }
}
