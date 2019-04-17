using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Powerup
{
    public int cooldown;
    public int duration;
    public int amount;

    public bool isOnCooldown = false;
    public bool isActive = false;
    public bool isUnlocked;

    public int cooldownLevel = 0;
    public int durationLevel = 0;
    public int amountLevel = 0;
    
    public int cooldownPrice = 200;
    public int durationPrice = 200;
    public int amountPrice = 200;

    public void CheckCoolDown(Image cooldownImage)
    {
        if (isOnCooldown)
        {
            cooldownImage.fillAmount -= 1.0f / cooldown * Time.deltaTime;

            if (cooldownImage.fillAmount == 0)
            {
                isOnCooldown = false;
            }
        }
    }
}
