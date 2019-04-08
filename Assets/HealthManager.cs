using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int healthPoints = 100;
    public static Text health;

    // Start is called before the first frame update
    void Start()
    {
        HealthManager.health = GetComponent<Text>();
        HealthManager.health.text = "HP: " + HealthManager.healthPoints;
    }

    // Update is called once per frame
    public static void UpdateScore(int wordLength)
    {
        HealthManager.healthPoints -= wordLength * 4;
        if (HealthManager.healthPoints <= 0)
        {   
            HealthManager.healthPoints = 0;
            GameManager.EndGame();
        }
        HealthManager.health.text = "HP: " + HealthManager.healthPoints;
    }
}
