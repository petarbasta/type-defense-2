using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FreezePowerup : Powerup
{
    public float startTime;
    public float timeLeftOver;

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

    public void Trigger(Image cooldownImage)
    {
        cooldownImage.fillAmount = 1;
        isOnCooldown = true;
        isActive = true;

        if (SaveLoad.playerProgress.slow.isActive)
        {
            SaveLoad.playerProgress.slow.EndEarly();
        }
 
        startTime = Time.time;
        GameManager.generate = false;
    }

    public void CheckIfComplete()
    {
        if (isActive && Time.time > duration + startTime)
        {
            isActive = false;
            GameManager.generate = true;
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
