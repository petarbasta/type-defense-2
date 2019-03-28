using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {"word1", "word2", "word11"};

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0,wordList.Length);
        string randomWord = wordList[randomIndex];
        return randomWord;
    }
}
