using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public WordSpawner wordSpawner;
    public WordGenerator wordGenerator;
    public int redZoneHeight = 0;

    public void Start()
    {
        wordGenerator.LoadAllWords();
    }

    public void AddWord()
    {
        WordDisplay wordDisplay = wordSpawner.SpawnWord();
        Word word = new Word(wordGenerator.GetRandomWord(), wordDisplay);
        words.Add(word);
    }

    public bool TypeWord (string input)
    {
        foreach(Word word in words)
        {
            if (string.Compare(input,word.word) == 0)
            {
                words.Remove(word);
                word.RemoveWord();
                return true;
            }
        }
        return false;
    }

    public void OnGUI()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            while (WordInput.keyboardHeight == 0)
            {
            }
            redZoneHeight = WordInput.keyboardHeight;
        }
    }

}
