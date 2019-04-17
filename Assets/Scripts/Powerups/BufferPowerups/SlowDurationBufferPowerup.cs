using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDurationBufferPowerup : BufferPowerup
{
    // Start is called before the first frame update
    void Start()
    {
        powerup = SaveLoad.playerProgress.slow;
        level = SaveLoad.playerProgress.slow.durationLevel;
        price = SaveLoad.playerProgress.slow.durationPrice;
    }
}
