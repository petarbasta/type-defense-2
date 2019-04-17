using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeDurationBufferPowerup : BufferPowerup
{
    // Start is called before the first frame update
    void Start()
    {
        powerup = SaveLoad.playerProgress.freeze;
        level = SaveLoad.playerProgress.freeze.durationLevel;
        price = SaveLoad.playerProgress.freeze.durationPrice;  
    }
}
