using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public WordSpawner wordSpawner;
    public WordGenerator wordGenerator;

    public void Start()
    {
        wordGenerator = FindObjectOfType<WordGenerator>();

        if (!GameManager.gameHasEnded)
        {
            AddWord();
        }
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
}
