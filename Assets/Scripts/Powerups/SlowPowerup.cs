using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlowPowerup : Powerup
{
    public float startTime;
    public float holdWordDelay;

    public SlowPowerup()
    {
        duration = 3;
        amount = 70;
        cooldown = 40;
    }

     public void Reset(Image cooldownImage)
    {
        cooldownImage.fillAmount = 0;
    }

    public void Trigger(Image cooldownImage)
    {
        holdWordDelay = GameManager.wordDelay;
        GameManager.wordDelay = GameManager.wordDelay * GameManager.fallSpeed/amount;

        cooldownImage.fillAmount = 1;
        isOnCooldown = true;
        isActive = true;

        startTime = Time.time;
    }

    public void CheckIfComplete(WordTimer wordTimer)
    {
        if (isActive && Time.time > duration + startTime && !SaveLoad.playerProgress.freeze.isActive)
        {
            //Checks when to spawn next word
            float timeUntilNextWord = wordTimer.nextWordTime - Time.time;
            float percentFast = timeUntilNextWord/holdWordDelay;
            float timeSpentSlow = holdWordDelay - timeUntilNextWord;
            float percentSlow = timeSpentSlow/holdWordDelay;

            wordTimer.nextWordTime = percentFast*holdWordDelay + percentSlow*GameManager.wordDelay;
            GameManager.wordDelay = holdWordDelay;
            isActive = false;
        }
    }

    public void EndEarly()
    {
        GameManager.wordDelay = holdWordDelay;
        isActive = false;
    }
}
