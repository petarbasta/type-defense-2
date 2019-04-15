using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;
    public WordGenerator wordGenerator;
    public GameManager gameManager;

    public float nextWordTime = 0f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Time.time >= nextWordTime && wordGenerator.words[0].Length > 0 && GameManager.generate)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + gameManager.wordDelay;
            gameManager.wordDelay *= .995f;
        }
    }
}
