using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProgress
{
    public int nukeCooldown;
    public bool isNukeUnlocked;

    public int freezeCooldown;
    public int freezeLength;
    public bool isFreezeUnlocked;

    public int slowCooldown;
    public int slowLength;
    public int slowSpeed;


    public PlayerProgress()
    {
        nukeCooldown = 45;
        isNukeUnlocked = false;

        freezeCooldown = 45;
        freezeLength = 3;
        isFreezeUnlocked = false;

        slowCooldown = 45;
        slowLength = 3;
        slowSpeed = 40;
    }
}
