using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCooldownBufferPowerup : BufferPowerup
{
    // Start is called before the first frame update
    void Start()
    {
        powerup = SaveLoad.playerProgress.slow;
        level = SaveLoad.playerProgress.slow.cooldownLevel;
        price = SaveLoad.playerProgress.slow.cooldownPrice;

    }
}
