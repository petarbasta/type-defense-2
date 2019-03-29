using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordManager : MonoBehaviour
{

    public List<Word> words;
    public WordSpawner wordSpawner;
    private TouchScreenKeyboard keyboard;

    public void Start()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.ASCIICapable, false);
        WordGenerator.LoadAllWords();
    }

    public void AddWord()
    {
        WordDisplay wordDisplay = wordSpawner.SpawnWord();
        Word word = new Word(WordGenerator.GetRandomWord(3), wordDisplay);
        words.Add(word);
    }

    public bool TypeWord (string input)
    {
        foreach(Word word in words)
        {
            if (string.Compare(input,word.word) == 0)
            {
                ScoreCounter.UpdateScore();
                words.Remove(word);
                word.RemoveWord();
                return true;
            }
        }
        return false;
    }

}
