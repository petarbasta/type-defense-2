using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;
    public WordGenerator wordGenerator;
    public GameManager gameManager;
    public float lastWordSpawnedTime;

    public float nextWordTime = 0f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Time.time >= nextWordTime && wordGenerator.words[0].Length > 0 && GameManager.generate)
        {
            lastWordSpawnedTime = Time.time;
            wordManager.AddWord();
            nextWordTime = Time.time + GameManager.wordDelay;

            if (GameManager.wordDelay > 0.1f)
            {
                GameManager.wordDelay *= 0.995f;
            }
        }
    }
}
