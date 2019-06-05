using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProgress
{
    public NukePowerup nuke;
    public FreezePowerup freeze;
    public SlowPowerup slow;
    
    public bool[] fontsUnlocked;
    public bool[] backgroundsUnlocked;

    public int gold;
    public int careerGold;
    public int highscore;
    public int totalScore;

    public int currentFont;
    public int currentFontColor;
    public int currentBackground;

    public PlayerProgress()
    {
        nuke = new NukePowerup();
        freeze = new FreezePowerup();
        slow = new SlowPowerup();

        careerGold = 0;
        gold = 1000000;
        highscore = 0;
        totalScore = 0;
        
        currentFont = 0;
        currentFontColor = 0;
        currentBackground = 0;

        fontsUnlocked = new bool[8];
        fontsUnlocked[0] = true;

        backgroundsUnlocked = new bool[6];
        backgroundsUnlocked[0] = true;
    }
}
