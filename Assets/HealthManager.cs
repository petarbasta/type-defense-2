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
        health = GetComponent<Text>();
        health.text = "HP: " + healthPoints;
    }

    // Update is called once per frame
    public void UpdateScore(int wordLength)
    {
        healthPoints -= wordLength * 4;
        if (healthPoints <= 0)
        {   
            healthPoints = 0;
            gameManager.EndGame();
        }
        health.text = "HP: " + healthPoints;
    }
}
