using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public GameManager gameManager;
    public static int health = 100;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "HP: " + health;
    }

    public void AddHealth(int wordLength)
    {
        health += wordLength;

        if (health > 100)
        {
            health = 100;
        }

        healthText.text = "HP: " + health;
    }

    public void SubtractHealth(int wordLength)
    {
        health -= wordLength * 3;
        if (health <= 0)
        {   
            health = 0;
            gameManager.EndGame();
        }
        healthText.text = "HP: " + health;
    }
}
