using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;
    public WordGenerator wordGenerator;


    public float wordDelay = 1.5f;
    public float nextWordTime = 0f;

    private void Update()
    {
        if (Time.time >= nextWordTime && wordGenerator.words[0].Length > 0)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
        }
    }
}
