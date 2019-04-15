using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class QuitPowerup : Powerup
{
    public QuitPowerup()
    {
    }

    public void Trigger()
    {
        SceneManager.LoadScene("StartScreen");

    }
}
