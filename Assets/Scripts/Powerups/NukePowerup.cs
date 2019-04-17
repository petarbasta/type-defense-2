using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NukePowerup : Powerup
{
    public int unlockPrice;

    public NukePowerup()
    {
        cooldown = 50;
        unlockPrice = 1000;
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
    }

    public void CheckIfComplete()
    {
        if (isActive)
        {
            isActive = false;
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
