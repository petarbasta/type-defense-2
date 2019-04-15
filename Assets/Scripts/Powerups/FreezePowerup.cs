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

    public FreezePowerup()
    {
        duration = 3;
        cooldown = 45;
        isUnlocked = false;
    }

    public void Reset(Image cooldownImage)
    {
        cooldownImage.fillAmount = 0;
    }

    public void Trigger(GameManager gameManager, float nextWordTime, Image cooldownImage)
    {
        cooldownImage.fillAmount = 1;
        isOnCooldown = true;
        isActive = true;

        timeLeftOver = nextWordTime - Time.time;
        startTime = Time.time;

        gameManager.generate = false;
    }

    public void CheckIfComplete(GameManager gameManager, WordTimer wordTimer)
    {
        if (isActive && Time.time > duration + startTime)
        {
            gameManager.generate = true;
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
