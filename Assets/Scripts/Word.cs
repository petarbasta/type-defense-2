using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    WordDisplay display;
    public float initialWordDelay;

    public Word (string _word, WordDisplay _display, float _initialWordDelay) 
    {
        word = _word;
        display = _display;
        initialWordDelay = _initialWordDelay;
        display.SetWord(word);
    }

    public void RemoveWord()
    {   
        display.RemoveWord(initialWordDelay);
    }
}
