using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordGenerator : MonoBehaviour
{
    private static List<List<string>> wordList = new List<List<string>>();
    public static int minNumberOfLetters = 3;
    public static int maxNumberOfLetters = 4;

    public static string GetRandomWord(int numberOfLetters)
    {
        int randomIndex = Random.Range(0,wordList[numberOfLetters - minNumberOfLetters].Count);
        string randomWord = wordList[numberOfLetters - minNumberOfLetters][randomIndex];
        return randomWord;
    }

    public static void LoadWords(int numberOfLetters)
    {
        string path = "Words/" + numberOfLetters + " Letter Words.txt";

        StreamReader reader = new StreamReader(path); 
        
        List<string> words = new List<string>();
        string line;

        do
        {
            line = reader.ReadLine();

            if (line != null)
            {
                words.Add(line);
            }
        }
        while (line != null);

        wordList.Add(words);
    }

    public static void LoadAllWords(){
        for (int i = minNumberOfLetters; i <= maxNumberOfLetters; i++ )
        {
            LoadWords(i);
        }
    }
}
