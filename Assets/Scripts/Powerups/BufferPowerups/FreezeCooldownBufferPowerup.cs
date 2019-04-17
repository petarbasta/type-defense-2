using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCooldownBufferPowerup : BufferPowerup
{
    // Start is called before the first frame update
    void Start()
    {        
        powerup = SaveLoad.playerProgress.freeze;
        level = SaveLoad.playerProgress.freeze.cooldownLevel;
        price = SaveLoad.playerProgress.freeze.cooldownPrice;
    }
}
