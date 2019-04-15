using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Powerup
{
    public int cooldown;

    public bool isOnCooldown = false;
    public bool isActive = false;
    public bool isUnlocked;

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
