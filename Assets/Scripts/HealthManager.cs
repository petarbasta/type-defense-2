using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameManager gameManager;
    public int healthPoints = 100;
    public Text health;

    // Start is called before the first frame update
    void Start()
    {
        health.text = "HP: " + healthPoints;
    }

    public void AddHealth(int wordLength)
    {
        healthPoints += wordLength;

        if (healthPoints > 100)
        {
            healthPoints = 100;
        }

        health.text = "HP: " + healthPoints;
    }

    public void SubtractHealth(int wordLength)
    {
        healthPoints -= wordLength * 3;
        if (healthPoints <= 0)
        {   
            healthPoints = 0;
            gameManager.EndGame();
        }
        health.text = "HP: " + healthPoints;
    }
}
