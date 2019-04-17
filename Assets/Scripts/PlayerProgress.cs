using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProgress
{
    public NukePowerup nuke;
    public FreezePowerup freeze;
    public SlowPowerup slow;

    public int gold;
    public int highscore;
    public int totalScore;
    public int rank;

    public PlayerProgress()
    {
        nuke = new NukePowerup();

        freeze = new FreezePowerup();
        slow = new SlowPowerup();

        gold = 1000000;
        highscore = 0;
        totalScore = 0;
        rank = 0;

    }
}
