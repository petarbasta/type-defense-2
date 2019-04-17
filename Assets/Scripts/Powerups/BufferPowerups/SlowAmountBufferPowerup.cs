using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAmountBufferPowerup : BufferPowerup
{
    // Start is called before the first frame update
    void Start()
    {
        powerup = SaveLoad.playerProgress.slow;
        level = SaveLoad.playerProgress.slow.amountLevel;
        price = SaveLoad.playerProgress.slow.amountPrice;
    }
}
