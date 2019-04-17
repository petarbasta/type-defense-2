using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeCooldownBufferPowerup : BufferPowerup
{
    // Start is called before the first frame update
    void Start()
    {
        powerup = SaveLoad.playerProgress.nuke;
        level = SaveLoad.playerProgress.nuke.cooldownLevel;
        price = SaveLoad.playerProgress.nuke.cooldownPrice;

    }
}
