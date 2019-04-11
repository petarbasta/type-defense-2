using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;
    public WordGenerator wordGenerator;
    public GameManager gameManager;

    public float wordDelay = 1.75f;
    public float nextWordTime = 0f;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Time.time >= nextWordTime && wordGenerator.words[0].Length > 0 && gameManager.generate)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .995f;
        }
    }
}
